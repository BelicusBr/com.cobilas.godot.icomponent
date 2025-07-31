using System;

namespace Cobilas.GodotEngine.Component;
/// <summary>Signals to the <seealso cref="InternalComponentHub.AddRequireComponent(Godot.Node?)"/> 
/// method which components to add to the <seealso cref="Godot.Node"/> object.</summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public sealed class RequireComponentAttribute(params Type[] components) : Attribute {
    private readonly Type[] components = components;
    /// <summary>The types of components to be added.</summary>
    /// <returns>Returns the types of components to be added.</returns>
    public Type[] Components => components;
    /// <summary>Creates a new instance of this object.</summary>
    public RequireComponentAttribute(Type component1, Type component2, Type component3) :
        this([component1, component2, component3]) { }
    /// <summary>Creates a new instance of this object.</summary>
    public RequireComponentAttribute(Type component1, Type component2) : this([component1, component2]) { }
    /// <summary>Creates a new instance of this object.</summary>
    public RequireComponentAttribute(Type component) : this([component]) { }
}