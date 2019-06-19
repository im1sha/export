using Export.Base;

namespace Export
{
    public interface IDocumentGeneratorFactory
    {
        /// <summary>
        /// Creates <see cref="IDocumentGenerator{TContent}"/> for given <see cref="DocumentType"/> 
        /// </summary>
        /// <typeparam name="TContent">Content to process</typeparam>
        /// <param name="documentType">Output document type</param>
        /// <returns>Document generator</returns>
        IDocumentGenerator<TContent> Create<TContent>(DocumentType documentType);
    }
}
