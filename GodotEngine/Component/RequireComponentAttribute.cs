using System;

namespace Cobilas.GodotEngine.Component;
/// <summary>Sinaliza para o metodo <seealso cref="InternalComponentHub.AddRequireComponent(Godot.Node?)"/> quais
/// componentes a serem adicionados no objeto <seealso cref="Godot.Node"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public sealed class RequireComponentAttribute(params Type[] components) : Attribute {
    private readonly Type[] components = components;
    /// <summary>Os tipos de componentes a serem adicionados.</summary>
    /// <returns>Retorna os tipos de componentes a serem adicionados.</returns>
    public Type[] Components => components;
    /// <summary>Creates a new instance of this object.</summary>
    public RequireComponentAttribute(Type component1, Type component2, Type component3) :
        this([component1, component2, component3]) { }
    /// <summary>Creates a new instance of this object.</summary>
    public RequireComponentAttribute(Type component1, Type component2) : this([component1, component2]) { }
    /// <summary>Creates a new instance of this object.</summary>
    public RequireComponentAttribute(Type component) : this([component]) { }
}