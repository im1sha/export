using System.IO;

namespace Export.Base
{
    /// <summary>
    /// Represents document structure   
    /// </summary>
    public interface IDocumentBuilder
    {
        /// <summary>
        /// Writes document content to the given stream
        /// </summary>
        /// <param name="stream">Stream to write</param>
        void ToStream(Stream stream);
    }
}
