using System;

namespace Export
{
    public interface ICompositionRoot
    {
        /// <summary>
        /// Returns <see cref="object"/> related to the given <see cref="Type"/> 
        /// </summary>
        /// <param name="type">Type to resolve</param>
        /// <returns>Expected <see cref="object"/></returns>
        object Resolve(Type type);
    }
}
