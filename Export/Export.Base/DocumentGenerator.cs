using System;
using System.IO;

namespace Export.Base
{
    /// <summary>
    /// Generates content of type <see cref="TContent"/> to document using the given structure representation (<see cref="TBuilder"/>)  
    /// </summary>
    /// <typeparam name="TBuilder">Document structure representation</typeparam>
    /// <typeparam name="TContent">Content to fill the document</typeparam>
    public class DocumentGenerator<TBuilder, TContent> : IDocumentGenerator<TContent> where TBuilder : class, IDocumentBuilder
    {
        /// <summary>
        /// Document structure representation
        /// </summary>
        private readonly TBuilder _documentBuilder;

        /// <summary>
        /// Maps TContent to TBuilder
        /// </summary>
        private readonly IDocumentContentMapper<TBuilder, TContent> _documentContentMapper;

        public DocumentGenerator(TBuilder documentBuilder, IDocumentContentMapper<TBuilder, TContent> documentContentMapper)
        {
            _documentBuilder = documentBuilder ?? throw new ArgumentNullException(nameof(documentBuilder));
            _documentContentMapper = documentContentMapper ?? throw new ArgumentNullException(nameof(documentContentMapper));
        }

        /// <summary>
        /// Writes formatted content to the <see cref="Stream"/>
        /// </summary>
        /// <param name="outputStream">Output stream</param>
        /// <param name="documentContent">Content for document generation</param>
        public void Generate(Stream outputStream, TContent documentContent)
        {
            _documentContentMapper.MapContent(_documentBuilder, documentContent);
            _documentBuilder.ToStream(outputStream);
        }
    }

}
