using Godot;
using System;
using System.Collections.Generic;

namespace Cobilas.GodotEngine.Component;

/// <summary>Uma interface para transformar um objeto <see cref="Godot.Node"/> em pseudo Componente.</summary>
public interface IComponentHub : IEnumerable<Node>
{
    /// <summary>O objeto pai.</summary>
    /// <returns>Retorna o objeto pai.</returns>
    Node? Parent { get; }
    /// <summary>A quantidade de objetos filho.</summary>
    /// <returns>Retorna a quantidade de objetos filho.</returns>
    int ComponentsCount { get; }
    /// <summary>O objeto pai como <seealso cref="IComponentHub"/>.</summary>
    /// <returns>Retorna o objeto pai como <seealso cref="IComponentHub"/>.</returns>
    IComponentHub? ParentComponent { get; }
    /// <summary>Obtem o componente por meio do tipo especificado.</summary>
    /// <param name="component">O tipo a ser obtido.</param>
    /// <param name="recursive">Permite procurar em sub-filhos.</param>
    /// <returns>Retorna o tipo de componente como nó.</returns>
    Node? GetComponent(Type? component, bool recursive);
    /// <inheritdoc cref="GetComponent(Type?, bool)"/>
    Node? GetComponent(Type? component);
    /// <inheritdoc cref="GetComponent(Type?, bool)"/>
    /// <typeparam name="TypeComponent">O tipo a ser obtido.</typeparam>
    TypeComponent? GetComponent<TypeComponent>(bool recursive) where TypeComponent : Node;
    /// <inheritdoc cref="GetComponent{TypeComponent}(bool)"/>
    TypeComponent? GetComponent<TypeComponent>() where TypeComponent : Node;
    /// <summary>Obtem os componentes por meio do tipo especificado.</summary>
    /// <param name="component">O tipo a ser obtido.</param>
    /// <param name="recursive">Permite procurar em sub-filhos.</param>
    /// <returns>Retorna os tipos de componentes como uma lista de nó.</returns>
    Node[]? GetComponents(Type? component, bool recursive);
    /// <inheritdoc cref="GetComponents(Type?, bool)"/>
    Node[]? GetComponents(Type? component);
    /// <inheritdoc cref="GetComponents(Type?, bool)"/>
    /// <typeparam name="TypeComponent">O tipo a ser obtido.</typeparam>
    TypeComponent[]? GetComponents<TypeComponent>(bool recursive) where TypeComponent : Node;
    /// <inheritdoc cref="GetComponents{T}(bool)"/>
    TypeComponent[]? GetComponents<TypeComponent>() where TypeComponent : Node;
    /// <summary>Permite adicionar um componente especificado o seu tipo.</summary>
    /// <param name="component">O tipo a ser adicionado.</param>
    /// <returns>Retorna o tipo que foi adicionado.</returns>
    Node? AddComponent(Type? component);
    /// <inheritdoc cref="AddComponent(Type?)"/>
    /// <typeparam name="TypeComponent">O tipo a ser adicionado.</typeparam>
    TypeComponent? AddComponent<TypeComponent>() where TypeComponent : Node;
    /// <summary>Permite adicionar varios componentes especificado o seu tipo.</summary>
    /// <param name="components">O tipos a serem adicionados.</param>
    void AddComponents(params Type[]? components);
    /// <summary>Permite adicionar um objeto <seealso cref="Godot.Node"/> a lista de componentes.</summary>
    /// <param name="component">O objeto <seealso cref="Godot.Node"/> a ser adicionado.</param>
    void AddNodeComponent(Node? component);
    /// <summary>Permite adicionar varios objetos <seealso cref="Godot.Node"/> a lista de componentes.</summary>
    /// <param name="components">Os objetos <seealso cref="Godot.Node"/> a serem adicionados.</param>
    void AddNodeComponents(params Node[]? components);
    /// <summary>Permite remover um objeto <seealso cref="Godot.Node"/> a lista de componentes.</summary>
    /// <param name="component">O objeto <seealso cref="Godot.Node"/> a ser removido.</param>
    /// <returns>Retorna <c>true</c> se a opração for bem sucedida.</returns>
    bool RemoveComponent(Node? component);
    /// <summary>Permite remover varios objetos <seealso cref="Godot.Node"/> a lista de componentes.</summary>
    /// <param name="components">Os objetos <seealso cref="Godot.Node"/> a serem removidos.</param>
    void RemoveComponents(params Node[]? components);
}