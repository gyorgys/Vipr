using System;

namespace Microsoft.OneDrive.RestProxy
{
    public interface IConcreteTypeAccessor
    {
        Type ConcreteType { get; }
        Type ElementType { get; }
    }
}