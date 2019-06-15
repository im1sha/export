using Export.Base;

namespace Export.Txt
{
    /// <summary>
    /// Represents structure of .txt document
    /// </summary>
    public interface ITxtDocumentBuilder : IDocumentBuilder
    {
        /// <summary>
        /// Adds string to the document
        /// </summary>
        /// <param name="text">Content to add</param>
        void AddString(string text);
    }

}
