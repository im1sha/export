using Export.Base;
using Export.Pdf;
using Export.Txt;
using Export.Xlsx;
using System;

namespace Export
{
    public class DefaultDocumentGeneratorFactory : IDocumentGeneratorFactory
    {
        private readonly ICompositionRoot _compositionRoot;

        public DefaultDocumentGeneratorFactory(ICompositionRoot compositionRoot)
        {
            _compositionRoot = compositionRoot ?? throw new ArgumentNullException(nameof(compositionRoot));
        }

        public IDocumentGenerator<TContent> Create<TContent>(DocumentType documentType)
        {
            switch (documentType)
            {
                case DocumentType.Xslx:
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
