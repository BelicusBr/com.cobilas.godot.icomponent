using Godot;
using System;
using System.Collections.Generic;

namespace Cobilas.GodotEngine.Component;

public interface IComponentHub : IEnumerable<Node> {
    Node? Parent { get; }
    int ComponentsCount { get; }
    IComponentHub? ParentComponent { get; }

    Node? GetComponent(Type? component);
    Node? GetComponent(Type? component, bool recursive);
    T? GetComponent<T>() where T : Node;
    T? GetComponent<T>(bool recursive) where T : Node;

    Node[]? GetComponents(Type? component);
    Node[]? GetComponents(Type? component, bool recursive);
    T[]? GetComponents<T>() where T : Node;
    T[]? GetComponents<T>(bool recursive) where T : Node;

    Node? AddComponent(Type? component);
    void AddComponents(params Type[]? components);
    T? AddComponent<T>() where T : Node;

    void AddNodeComponent(Node? component);
    void AddNodeComponents(params Node[]? components);

    bool RemoveComponent(Node? component);
    void RemoveComponents(params Node[]? components);
}