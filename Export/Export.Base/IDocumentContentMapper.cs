namespace Export.Base
{
    public interface IDocumentContentMapper<TDocumentBuilder, TContent>
    {
        /// <summary>
        /// Maps content <see cref="TContent"/> to the
        /// document structure (<see cref="TDocumentBuilder"/>)
        /// </summary>
        /// <param name="documentBuilder">Document structure representation</param>
        /// <param name="content">Content to map</param>
        void MapContent(TDocumentBuilder documentBuilder, TContent content);
    }
}
