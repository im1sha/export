using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Base
{
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

}
