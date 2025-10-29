# Cobilas Godot IComponent
This package aims to transform a `Node` object into a pseudo-component in the style of the `Unity Engine` to facilitate obtaining objects and adding child objects.

## Usage
To use the `IComponentHub` interface, it must be inherited by a `Node` object, and you can also use the serializable `InternalComponentHub` class to automate the addition, removal, and retrieval of child `Node` objects.
However, implementing the `IComponentHub` interface manually will only require a little work.

## Exemplo
```c#
using Godot;
using Cobilas.GodotEngine.Component;

public class MonoNode : Node, IComponentHub {
    private InternalComponentHub components;

    public Node Parent => components.Parent;
    public int ComponentsCount => components.ComponentsCount;
    public IComponentHub ParentComponent => components.ParentComponent;

    public Node AddComponent(Type component) => components.AddComponent(component);
    public T AddComponent<T>() where T : Node => ((IComponentHub)components).AddComponent<T>();
    public void AddComponents(params Type[] components) => this.components.AddComponents(components);
    public void AddNodeComponent(Node component) => components.AddNodeComponent(component);
    public void AddNodeComponents(params Node[] components) => this.components.AddNodeComponents(components);
    public Node GetComponent(Type component) => components.GetComponent(component);
    public Node GetComponent(Type component, bool recursive) => components.GetComponent(component, recursive);
    public T GetComponent<T>() where T : Node => ((IComponentHub)components).GetComponent<T>();
    public T GetComponent<T>(bool recursive) where T : Node => ((IComponentHub)components).GetComponent<T>(recursive);
    public Node[] GetComponents(Type component) => components.GetComponents(component);
    public Node[] GetComponents(Type component, bool recursive) => components.GetComponents(component, recursive);
    public T[] GetComponents<T>() where T : Node => ((IComponentHub)components).GetComponents<T>();
    public T[] GetComponents<T>(bool recursive) where T : Node => ((IComponentHub)components).GetComponents<T>(recursive);
    public IEnumerator<Node> GetEnumerator() => components.GetEnumerator();
    public bool RemoveComponent(Node component) => components.RemoveComponent(component);
    public void RemoveComponents(params Node[] components) => this.components.RemoveComponents(components);
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)components).GetEnumerator();

    protected override void Dispose(bool disposing) {
        base.Dispose(disposing);
        components?.Dispose();
    }
}
```

## The [Cobilas Godot IComponent](https://www.nuget.org/packages/Cobilas.Godot.IComponent/) is on nuget.org
To include the package, open the `.csproj` file and add it.
```xml
<ItemGroup>
	<PackageReference Include="Cobilas.Godot.IComponent" Version="1.1.2" />
</ItemGroup>
```
Or use command line.
```
dotnet add package Cobilas.Godot.IComponent --version 1.1.2
```