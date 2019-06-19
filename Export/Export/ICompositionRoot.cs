using System;

namespace Export
{
    public interface ICompositionRoot
    {
        object Resolve(Type type);
    }

}
