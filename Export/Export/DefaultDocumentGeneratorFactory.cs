using Export.Base;
using Export.Pdf;
using Export.Txt;
using Export.Xlsx;
using System;

namespace Export
{
    public class DefaultDocumentGeneratorFactory : IDocumentGeneratorFactory
    {
        /// <summary>
        /// Object intended to resolve relations between 
        /// content to process/requred output format and 
        /// existing <see cref="DocumentGenerator{TBuilder, TContent}"/>
        /// </summary>
        private readonly ICompositionRoot _compositionRoot;

        public DefaultDocumentGeneratorFactory(ICompositionRoot compositionRoot)
        {
            _compositionRoot = compositionRoot ?? throw new ArgumentNullException(nameof(compositionRoot));
        }

        /// <summary>
        /// Creates <see cref="IDocumentGenerator{TContent}"/> 
        /// intended to process given content
        /// and generate requested <see cref="DocumentType"/>
        /// </summary>
        /// <typeparam name="TContent">Content to process</typeparam>
        /// <param name="documentType">Output type</param>
        /// <returns>Requested generator</returns>
        public IDocumentGenerator<TContent> Create<TContent>(DocumentType documentType)
        {
            switch (documentType)
            {
                case DocumentType.Xlsx:
                    return (IDocumentGenerator<TContent>)_compositionRoot.Resolve(
                        typeof(DocumentGenerator<IXlsxDocumentBuilder, TContent>));
                case DocumentType.Pdf:
                    return (IDocumentGenerator<TContent>)_compositionRoot.Resolve(
                        typeof(DocumentGenerator<IPdfDocumentBuilder, TContent>));
                case DocumentType.Txt:
                    return (IDocumentGenerator<TContent>)_compositionRoot.Resolve(
                        typeof(DocumentGenerator<ITxtDocumentBuilder, TContent>));
                default:
                    throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null);
            }
        }
    }
}
