using System;

namespace Cobilas.GodotEngine.Component;

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public sealed class RequireComponentAttribute(params Type[] components) : Attribute {
    private readonly Type[] components = components;

    public Type[] Components => components;

    public RequireComponentAttribute(Type component1, Type component2, Type component3) :
        this([component1, component2, component3]) { }

    public RequireComponentAttribute(Type component1, Type component2) : this([component1, component2]) { }
        
    public RequireComponentAttribute(Type component) : this([component]) { }
}