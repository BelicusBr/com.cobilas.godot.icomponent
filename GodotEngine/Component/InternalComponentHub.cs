using Godot;
using System;
using System.Reflection;
using System.Collections;
using Cobilas.Collections;
using System.Collections.Generic;
using Cobilas.GodotEngine.Utility;
using System.Diagnostics.CodeAnalysis;

namespace Cobilas.GodotEngine.Component;

[Serializable]
public sealed class InternalComponentHub : IInternalComponentHub, IDisposable
{
    private Node[]? components;
    private bool disposedValue;
    public Node? Entity { get; private set; }
    public int ComponentsCount => ArrayManipulation.ArrayLength(components);
    public Node? Parent => IsNull(Entity) ? NullNode.Null : Entity?.GetParent();
    public IComponentHub? ParentComponent => Entity is null ? NullComponentHub.Null : Parent is IComponentHub comp ? comp : NullComponentHub.Null;
    //Entity?.GetParent() is IComponentHub icph ? icph : null;

    public InternalComponentHub(Node entity)
    {
        Entity = entity ?? NullNode.Null;
    }

    // // TODO: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
    ~InternalComponentHub() => Dispose(disposing: false);

    public Node? GetComponent(Type? component, bool recursive) {
        if (component is null) return NullNode.Null;
        else if (!component.CompareTypeAndSubType<Node>())
            throw new ArgumentException("Is not Node");
        else if (ComponentsCount != 0 && components is not null)
            foreach (Node item in components) {
                if (item.CompareTypeAndSubType(component)) return item;
                else if (item is IComponentHub comp && recursive) {
                    Node? result = comp.GetComponent(component, recursive);
                    if (result is not null) return result;
                }
            }
        return NullNode.Null;
    }

    public Node? GetComponent(Type? component) => GetComponent(component, false);

    public TypeComponent? GetComponent<TypeComponent>(bool recursive) where TypeComponent : Node
        => (TypeComponent?)GetComponent(typeof(TypeComponent), recursive);

    public TypeComponent? GetComponent<TypeComponent>() where TypeComponent : Node
        => GetComponent<TypeComponent>(false);

    public Node[]? GetComponents(Type? component, bool recursive) {
        if (component is null || ComponentsCount == 0 || components is null) return Array.Empty<Node>();
        else if (!component.CompareTypeAndSubType<Node>())
            throw new ArgumentException("Is not Node");

        Node[]? resultList = Array.Empty<Node>();
        foreach (Node item in components) {
            if (item.CompareTypeAndSubType(component))
                ArrayManipulation.Add(item, ref resultList);
            if (item is IComponentHub comp && recursive) {
                Node[]? result = comp.GetComponents(component, recursive);
                if (!ArrayManipulation.EmpytArray(result))
                    ArrayManipulation.Add(result, ref resultList);
            }
        }
        return resultList;
    }

    public Node[]? GetComponents(Type? component) => GetComponents(component, false);

    public TypeComponent[]? GetComponents<TypeComponent>(bool recursive) where TypeComponent : Node {
        Node[]? nodes = GetComponents(typeof(TypeComponent), recursive);
        if (nodes is TypeComponent[] list) return list;
        return ArrayManipulation.ConvertAll(nodes, n => (TypeComponent)n);
    }

    public TypeComponent[]? GetComponents<TypeComponent>() where TypeComponent : Node {
        Node[]? nodes = GetComponents(typeof(TypeComponent), false);
        if (nodes is TypeComponent[] list) return list;
        return ArrayManipulation.ConvertAll(nodes, n => (TypeComponent)n);
    }

    public Node? AddComponent(Type? component) {
        if (component is null || Entity is null) return NullNode.Null;
        else if (!component.CompareTypeAndSubType<Node>())
            throw new ArgumentException("Is not Node");

        Node result = component.Activator<Node>();
        result.Name = component.Name;
        ArrayManipulation.Add(result, ref components);
        Entity.AddChild(result);
        result.SetNodePosition(Vector3.Zero);
        return result;
    }

    public void AddComponents(params Type[]? components) {
        if (components is not null)
            foreach (Type item in components)
                AddComponent(item);
    }

    public TypeComponent? AddComponent<TypeComponent>() where TypeComponent : Node
        => (TypeComponent?)AddComponent(typeof(TypeComponent));

    public void AddNodeComponent(Node? component)
    {
        if (components is not null)
            ArrayManipulation.Add(component, ref components);
    }

    public void AddNodeComponents(params Node[]? components)
    {
        if (components is not null)
            foreach (Node item in components)
                AddNodeComponent(item);
    }

    public bool RemoveComponent(Node? component) {
        if (components is null || Entity is null) return false;
        if (!ArrayManipulation.Exists(component, components)) return false;
        ArrayManipulation.Remove(component, ref components);
        Entity.RemoveChild(component);
        return true;
    }

    public void RemoveComponents(params Node[]? components) {
        if (components is not null)
            foreach (Node item in components)
                _ = RemoveComponent(item);
    }

    public void Dispose() {
        // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public IEnumerator<Node> GetEnumerator() => new ArrayToIEnumerator<Node>(components ?? []);

    IEnumerator IEnumerable.GetEnumerator() => new ArrayToIEnumerator<Node>(components ?? []);

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                foreach (Node item in this)
                    item?.Dispose();
                _ = ParentComponent?.RemoveComponent(this.Entity);
            }
            disposedValue = true;
        }
    }

    public static void AddRequireComponent(Node? mono) {
        if (mono is null) return;
        RequireComponentAttribute require = mono.GetType().GetCustomAttribute<RequireComponentAttribute>(true);
        if (require is not null) {
            Node? parent = mono.GetParent();
            foreach (Type type in require.Components)
                if ((mono is IComponentHub ? mono : parent) is not IComponentHub comp) {
                    Node node = type.Activator<Node>();
                    node.Name = type.Name;
                    mono.AddChild(node);
                } else { _ = comp.AddComponent(type); }
        }
    }

    private static bool IsNull(Node? node) => node is null || node is NullNode;
}
