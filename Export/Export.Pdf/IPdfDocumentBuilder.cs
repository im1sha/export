using Export.Base;

namespace Export.Pdf
{
    /// <summary>
    /// Represents structure of .pdf document
    /// </summary>
    public interface IPdfDocumentBuilder : IDocumentBuilder
    {
        /// <summary>
        /// Appends row of cells to current document structure
        /// </summary> 
        /// <param name="values">Values to append</param>
        void AddRow(string[] values);
    }
}
