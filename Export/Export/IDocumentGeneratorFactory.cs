using Export.Base;

namespace Export
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentGeneratorFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TContent"></typeparam>
        /// <param name="documentType"></param>
        /// <returns></returns>
        IDocumentGenerator<TContent> Create<TContent>(DocumentType documentType);
    }
}
