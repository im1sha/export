using System.IO;

namespace Export.Core
{
    public interface IFormatBuilder
    {
        void ToStream<T>(T item, Stream stream);
    }
}
