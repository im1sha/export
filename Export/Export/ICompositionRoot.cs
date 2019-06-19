using System;

namespace Export
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompositionRoot
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object Resolve(Type type);
    }
}
