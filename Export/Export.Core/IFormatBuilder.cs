using System.IO;

namespace Export.Core
{
    public interface IFormatBuilder
    {
        void ToStream(Stream stream);
    }
}
