using System;
using System.IO;

namespace Export
{
    public interface ICompositionRoot
    {
        object Resolve(Type type);
    }

    public enum DocumentType
    {
        Xslx,
        Pdf
    }

    public interface IDocumentContentMapper<TDocumentBuilder, TContent>
    {
        void MapContent(TDocumentBuilder documentBuilder, TContent content);
    }

    public interface IDocumentBuilder
    {
        void ToStream(Stream stream);
    }

    public interface IXslxDocumentBuilder: IDocumentBuilder
    {
        void SetCellValue(int rowIndex, int columnIndex, string value);
        // Xlsx document specific methods
    }

    public interface IPdfDocumentBuilder: IDocumentBuilder
    {
        // Pdf document specific methods
    }

    public interface ITxtDocumentBuilder : IDocumentBuilder
    {
        void AddString(string text);
    }

    public interface IDocumentGenerator<TContent>
    {
        void Generate(Stream outputStream, TContent documentContent);
    }

    public interface IDocumentGeneratorFactory
    {
        IDocumentGenerator<TContent> Create<TContent>(DocumentType documentType);
    }

    public class DocumentGenerator<TBuilder, TContent> : IDocumentGenerator<TContent> where TBuilder : class, IDocumentBuilder
    {
        private readonly TBuilder _documentBuilder;
        private readonly IDocumentContentMapper<TBuilder, TContent> _documentContentMapper;

        public DocumentGenerator(TBuilder documentBuilder, IDocumentContentMapper<TBuilder, TContent> documentContentMapper)
        {
            _documentBuilder = documentBuilder ?? throw new ArgumentNullException(nameof(documentBuilder));
            _documentContentMapper = documentContentMapper ?? throw new ArgumentNullException(nameof(documentContentMapper));
        }

        public void Generate(Stream outputStream, TContent documentContent)
        {
            _documentContentMapper.MapContent(_documentBuilder, documentContent);
            _documentBuilder.ToStream(outputStream);
        }
    }

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
                    return (IDocumentGenerator<TContent>) _compositionRoot.Resolve(
                        typeof(DocumentGenerator<IXslxDocumentBuilder, TContent>));
                case DocumentType.Pdf: return 
                    (IDocumentGenerator<TContent>)_compositionRoot.Resolve(
                        typeof(DocumentGenerator<IPdfDocumentBuilder, TContent>));
                default:
                    throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null);
            }
        }
    }
}