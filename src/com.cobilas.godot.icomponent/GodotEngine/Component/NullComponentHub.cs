using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using Cobilas.GodotEngine.Utility;

namespace Cobilas.GodotEngine.Component;
/// <summary>Represents a null ComponentHub.</summary>
public class NullComponentHub : Node, IComponentHub, INullObject {

    private static readonly NullComponentHub @null = new();
    /// <inheritdoc/>
    public int ComponentsCount => 0;
    /// <inheritdoc/>
    public Node? Parent => NullNode.Null;
    /// <inheritdoc/>
    public IComponentHub? ParentComponent => null;
    /// <summary>A representation of a null ComponentHub.</summary>
    /// <returns>Returns a representation of a null ComponentHub.</returns>
    public static NullComponentHub Null => @null;
    /// <inheritdoc/>
    public Node? AddComponent(Type? component) => NullNode.Null;
    /// <inheritdoc/>
    public T? AddComponent<T>() where T : Node => null;
    /// <inheritdoc/>
    public void AddComponents(params Type[]? components) { }
    /// <inheritdoc/>
    public void AddNodeComponent(Node? component) { }
    /// <inheritdoc/>
    public void AddNodeComponents(params Node[]? components) { }
    /// <inheritdoc/>
    public Node? GetComponent(Type? component) => NullNode.Null;
    /// <inheritdoc/>
    public Node? GetComponent(Type? component, bool recursive) => NullNode.Null;
    /// <inheritdoc/>
    public T? GetComponent<T>() where T : Node => null;
    /// <inheritdoc/>
    public T? GetComponent<T>(bool recursive) where T : Node => null;
    /// <inheritdoc/>
    public Node[]? GetComponents(Type? component) => Array.Empty<Node>();
    /// <inheritdoc/>
    public Node[]? GetComponents(Type? component, bool recursive) => Array.Empty<Node>();
    /// <inheritdoc/>
    public T[]? GetComponents<T>() where T : Node => Array.Empty<T>();
    /// <inheritdoc/>
    public T[]? GetComponents<T>(bool recursive) where T : Node => Array.Empty<T>();
    /// <inheritdoc/>
    public IEnumerator<Node> GetEnumerator() {
        yield break;
    }
    /// <inheritdoc/>
    public bool RemoveComponent(Node? component) => false;
    /// <inheritdoc/>
    public void RemoveComponents(params Node[]? components) { }
    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() {
        yield break;
    }
}
