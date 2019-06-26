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
                    return (IDocumentGenerator<TContent>)new XlsxDocumentGenerator(
                        new XlsxDocumentBuilder(),
                        new XlsxDocumentContentMapper());
                case DocumentType.Pdf:
                    return (IDocumentGenerator<TContent>)new PersonsPdfDocumentGenerator(
                        new PdfDocumentBuilder(),
                        new PersonsPdfDocumentContentMapper());
                case DocumentType.Txt:
                    return (IDocumentGenerator<TContent>)new PersonsSimpleTxtDocumentGenerator(
                        new SimpleTxtDocumentBuilder(),
                        new PersonsTxtDocumentContentMapper());
                default:
                    throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null);
            }
        }
    }
}
