using Godot;

namespace Cobilas.GodotEngine.Component;
/// <summary>Interface para classe interna para manipulação de <seealso cref="IComponentHub"/>.</summary>
public interface IInternalComponentHub : IComponentHub {
    /// <summary>O objeto <seealso cref="Godot.Node"/> que está associado.</summary>
    /// <returns>Retorna o objeto <seealso cref="Godot.Node"/> que está associado.</returns>
    Node? Entity { get; }
}
