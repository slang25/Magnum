namespace Magnum.Specs.CommandLine
{
    using System;

    public interface INamingConvention
    {
        string GetName<T>();
        string GetName(Type t);
    }
}