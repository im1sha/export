namespace Export.Base
{
    public interface IDocumentContentMapper<TDocumentBuilder, TContent>
    {
        void MapContent(TDocumentBuilder documentBuilder, TContent content);
    }
}
