using System.IO;

namespace Export.Base
{
    public interface IDocumentBuilder
    {
        void ToStream(Stream stream);
    }
}
