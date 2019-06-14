using System.IO;

namespace Export.Base
{
    public interface IDocumentGenerator<TContent>
    {
        void Generate(Stream outputStream, TContent documentContent);
    }
}
