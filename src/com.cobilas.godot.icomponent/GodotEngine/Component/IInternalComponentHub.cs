using Godot;

namespace Cobilas.GodotEngine.Component;
/// <summary>Interface for inner class for handling <seealso cref="IComponentHub"/>.</summary>
public interface IInternalComponentHub : IComponentHub {
    /// <summary>The <seealso cref="Godot.Node"/> object that is associated.</summary>
    /// <returns>Returns the associated <seealso cref="Godot.Node"/> object.</returns>
    Node? Entity { get; }
}
