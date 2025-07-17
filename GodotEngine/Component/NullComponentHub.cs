using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Cobilas.GodotEngine.Utility;

namespace Cobilas.GodotEngine.Component;

public class NullComponentHub : Node, IComponentHub, INullObject {

    private static readonly NullComponentHub @null = new();

    public int ComponentsCount => 0;
    public Node? Parent => NullNode.Null;
    public IComponentHub? ParentComponent => null;

    public static NullComponentHub Null => @null;

    public Node? AddComponent(Type? component) => NullNode.Null;

    public T? AddComponent<T>() where T : Node => null;

    public void AddComponents(params Type[]? components) { }

    public void AddNodeComponent(Node? component) { }

    public void AddNodeComponents(params Node[]? components) { }

    public Node? GetComponent(Type? component) => NullNode.Null;

    public Node? GetComponent(Type? component, bool recursive) => NullNode.Null;

    public T? GetComponent<T>() where T : Node => null;

    public T? GetComponent<T>(bool recursive) where T : Node => null;

    public Node[]? GetComponents(Type? component) => Array.Empty<Node>();

    public Node[]? GetComponents(Type? component, bool recursive) => Array.Empty<Node>();

    public T[]? GetComponents<T>() where T : Node => Array.Empty<T>();

    public T[]? GetComponents<T>(bool recursive) where T : Node => Array.Empty<T>();

    public IEnumerator<Node> GetEnumerator() {
        yield break;
    }

    public bool RemoveComponent(Node? component) => false;

    public void RemoveComponents(params Node[]? components) { }

    IEnumerator IEnumerable.GetEnumerator() {
        yield break;
    }
}
