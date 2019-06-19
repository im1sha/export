using System.IO;

namespace Export.Base
{
    /// <summary>
    /// Generates documents
    /// </summary>
    /// <typeparam name="TContent">Content to write</typeparam>
    public interface IDocumentGenerator<TContent>
    {
        /// <summary>
        /// Writes formatted content to the <see cref="Stream"/>
        /// </summary>
        /// <param name="outputStream">Output stream</param>
        /// <param name="documentContent">Content for document generation</param>
        void Generate(Stream outputStream, TContent documentContent);
    }
}
