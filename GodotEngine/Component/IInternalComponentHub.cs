using Godot;

namespace Cobilas.GodotEngine.Component;

public interface IInternalComponentHub : IComponentHub {
    Node? Entity { get; }
}
