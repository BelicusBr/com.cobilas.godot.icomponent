using Godot;
using System;
using System.Collections.Generic;

namespace Cobilas.GodotEngine.Component;

/// <summary>An interface to transform a <see cref="Godot.Node"/> object into a pseudo Component.</summary>
public interface IComponentHub : IEnumerable<Node>
{
    /// <summary>The parent object.</summary>
    /// <returns>Returns the parent object.</returns>
    Node? Parent { get; }
    /// <summary>The number of child objects.</summary>
    /// <returns>Returns the number of child objects.</returns>
    int ComponentsCount { get; }
    /// <summary>The parent object as <seealso cref="IComponentHub"/>.</summary>
    /// <returns>Returns the parent object as <seealso cref="IComponentHub"/>.</returns>
    IComponentHub? ParentComponent { get; }
    /// <summary>Gets the component by the specified type.</summary>
    /// <param name="component">The type to be obtained.</param>
    /// <param name="recursive">Allows searching in sub-children.</param>
    /// <returns>Returns the component type as node.</returns>
    Node? GetComponent(Type? component, bool recursive);
    /// <inheritdoc cref="GetComponent(Type?, bool)"/>
    Node? GetComponent(Type? component);
    /// <inheritdoc cref="GetComponent(Type?, bool)"/>
    /// <typeparam name="TypeComponent">The type to be obtained.</typeparam>
    TypeComponent? GetComponent<TypeComponent>(bool recursive) where TypeComponent : Node;
    /// <inheritdoc cref="GetComponent{TypeComponent}(bool)"/>
    TypeComponent? GetComponent<TypeComponent>() where TypeComponent : Node;
    /// <summary>Gets components by the specified type.</summary>
    /// <param name="component">The type to be obtained.</param>
    /// <param name="recursive">Allows searching in sub-children.</param>
    /// <returns>Returns the component types as a node list.</returns>
    Node[]? GetComponents(Type? component, bool recursive);
    /// <inheritdoc cref="GetComponents(Type?, bool)"/>
    Node[]? GetComponents(Type? component);
    /// <inheritdoc cref="GetComponents(Type?, bool)"/>
    /// <typeparam name="TypeComponent">The type to be obtained.</typeparam>
    TypeComponent[]? GetComponents<TypeComponent>(bool recursive) where TypeComponent : Node;
    /// <inheritdoc cref="GetComponents{T}(bool)"/>
    TypeComponent[]? GetComponents<TypeComponent>() where TypeComponent : Node;
    /// <summary>Allows you to add a component by specifying its type.</summary>
    /// <param name="component">The type to be added.</param>
    /// <returns>Returns the type that was added.</returns>
    Node? AddComponent(Type? component);
    /// <inheritdoc cref="AddComponent(Type?)"/>
    /// <typeparam name="TypeComponent">The type to be added.</typeparam>
    TypeComponent? AddComponent<TypeComponent>() where TypeComponent : Node;
    /// <summary>Allows you to add multiple components by specifying their type.</summary>
    /// <param name="components">The types to be added.</param>
    void AddComponents(params Type[]? components);
    /// <summary>Allows you to add a <seealso cref="Godot.Node"/> object to the component list.</summary>
    /// <param name="component">The <seealso cref="Godot.Node"/> object to add.</param>
    void AddNodeComponent(Node? component);
    /// <summary>Allows you to add multiple <seealso cref="Godot.Node"/> objects to the component list.</summary>
    /// <param name="components">The <seealso cref="Godot.Node"/> objects to add.</param>
    void AddNodeComponents(params Node[]? components);
    /// <summary>Allows you to remove a <seealso cref="Godot.Node"/> object from the list of components.</summary>
    /// <param name="component">The <seealso cref="Godot.Node"/> object to remove.</param>
    /// <returns>Returns <c>true</c> if the operation is successful.</returns>
    bool RemoveComponent(Node? component);
    /// <summary>Allows you to remove several <seealso cref="Godot.Node"/> objects from the list of components.</summary>
    /// <param name="components">The <seealso cref="Godot.Node"/> objects to be removed.</param>
    void RemoveComponents(params Node[]? components);
}