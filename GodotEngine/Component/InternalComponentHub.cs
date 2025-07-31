using Godot;
using System;
using System.Reflection;
using System.Collections;
using Cobilas.Collections;
using System.Collections.Generic;
using Cobilas.GodotEngine.Utility;

namespace Cobilas.GodotEngine.Component;
/// <summary>Inner class for handling <seealso cref="IComponentHub"/>.</summary>
[Serializable]
public sealed class InternalComponentHub(Node entity) : IInternalComponentHub, IDisposable
{
    private Node[]? components;
    [NonSerialized] private bool disposedValue;
    /// <inheritdoc/>
    public Node? Entity { get; private set; } = entity ?? NullNode.Null;
    /// <inheritdoc/>
    public int ComponentsCount => ArrayManipulation.ArrayLength(components);
    /// <inheritdoc/>
    public Node? Parent => IsNull(Entity) ? NullNode.Null : Entity?.GetParent();
    /// <inheritdoc/>
    public IComponentHub? ParentComponent => Entity is null or NullNode ? NullComponentHub.Null : Parent is IComponentHub comp ? comp : NullComponentHub.Null;
    /// <summary>The destructor is responsible for discarding unmanaged resources.</summary>
    ~InternalComponentHub() => Dispose(disposing: false);
    /// <inheritdoc/>
    /// <remarks>If the specified type is null or not found in the component list, 
    /// an object of type <seealso cref="Cobilas.GodotEngine.Utility.NullNode"/> will be returned.</remarks>
    /// <exception cref="ArgumentException">Occurs when the specified type does not inherit from <seealso cref="Godot.Node"/>.</exception>
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
    /// <inheritdoc cref="GetComponent(Type?, bool)"/>
    public Node? GetComponent(Type? component) => GetComponent(component, false);
    /// <inheritdoc/>
    /// <remarks>If the specified type is null or not found in the component list, 
    /// an object of type <seealso cref="Cobilas.GodotEngine.Utility.NullNode"/> will be returned.</remarks>
    /// <exception cref="ArgumentException">Occurs when the specified type does not inherit from <seealso cref="Godot.Node"/>.</exception>
    public TypeComponent? GetComponent<TypeComponent>(bool recursive) where TypeComponent : Node
        => (TypeComponent?)GetComponent(typeof(TypeComponent), recursive);
    /// <inheritdoc cref="GetComponent{TypeComponent}(bool)"/>
    public TypeComponent? GetComponent<TypeComponent>() where TypeComponent : Node
        => GetComponent<TypeComponent>(false);
    /// <inheritdoc/>
    /// <remarks>If the specified type is null or not found in the component list, an empty list will be returned.</remarks>
    /// <exception cref="ArgumentException">Occurs when the specified type does not inherit from <seealso cref="Godot.Node"/>.</exception>
    public Node[]? GetComponents(Type? component, bool recursive) {
        if (component is null || ComponentsCount == 0 || components is null) return [];
        else if (!component.CompareTypeAndSubType<Node>())
            throw new ArgumentException("Is not Node");

        Node[]? resultList = [];
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
    /// <inheritdoc cref="GetComponents(Type?, bool)"/>
    public Node[]? GetComponents(Type? component) => GetComponents(component, false);
    /// <inheritdoc/>
    /// <remarks>If the specified type is null or not found in the component list, an empty list will be returned.</remarks>
    /// <exception cref="ArgumentException">Occurs when the specified type does not inherit from <seealso cref="Godot.Node"/>.</exception>
    public TypeComponent[]? GetComponents<TypeComponent>(bool recursive) where TypeComponent : Node {
        Node[]? nodes = GetComponents(typeof(TypeComponent), recursive);
        if (nodes is not null && nodes.Length == 0) return [];
        else if (nodes is TypeComponent[] list) return list;
        return ArrayManipulation.ConvertAll(nodes, n => (TypeComponent)n);
    }
    /// <inheritdoc cref="GetComponents{TypeComponent}(bool)"/>
    public TypeComponent[]? GetComponents<TypeComponent>() where TypeComponent : Node => GetComponents<TypeComponent>(false);
    /// <inheritdoc/>
    /// <remarks>If the specified type is null or not found in the component list, 
    /// an object of type <seealso cref="Cobilas.GodotEngine.Utility.NullNode"/> will be returned.</remarks>
    /// <exception cref="ArgumentException">Occurs when the specified type does not inherit from <seealso cref="Godot.Node"/>.</exception>
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
    /// <inheritdoc/>
    /// <exception cref="ArgumentException">Occurs when the specified type does not inherit from <seealso cref="Godot.Node"/>.</exception>
    public void AddComponents(params Type[]? components) {
        if (components is not null)
            foreach (Type item in components)
                AddComponent(item);
    }
    /// <inheritdoc/>
    /// <remarks>If the specified type is null or not found in the component list, 
    /// an object of type <seealso cref="Cobilas.GodotEngine.Utility.NullNode"/> will be returned.</remarks>
    /// <exception cref="ArgumentException">Occurs when the specified type does not inherit from <seealso cref="Godot.Node"/>.</exception>
    public TypeComponent? AddComponent<TypeComponent>() where TypeComponent : Node
        => (TypeComponent?)AddComponent(typeof(TypeComponent));
    /// <inheritdoc/>
    public void AddNodeComponent(Node? component)
    {
        if (components is not null)
            ArrayManipulation.Add(component, ref components);
    }
    /// <inheritdoc/>
    public void AddNodeComponents(params Node[]? components)
    {
        if (components is not null)
            foreach (Node item in components)
                AddNodeComponent(item);
    }
    /// <inheritdoc/>
    public bool RemoveComponent(Node? component) {
        if (components is null || Entity is null) return false;
        if (!ArrayManipulation.Exists(component, components)) return false;
        ArrayManipulation.Remove(component, ref components);
        Entity.RemoveChild(component);
        return true;
    }
    /// <inheritdoc/>
    public void RemoveComponents(params Node[]? components) {
        if (components is not null)
            foreach (Node item in components)
                _ = RemoveComponent(item);
    }
    /// <inheritdoc/>
    public void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    /// <inheritdoc/>
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
    /// <summary>Static function to add components automatically.</summary>
    /// <remarks>The target <seealso cref="Godot.Node"/> object must have 
    /// the <seealso cref="RequireComponentAttribute"/> attribute to specify the types to be added.</remarks>
    /// <param name="mono">Target <seealso cref="Godot.Node"/> object.</param>
    /// <exception cref="ArgumentException">Occurs when the specified type does not inherit from <seealso cref="Godot.Node"/>.</exception>
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
