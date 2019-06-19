using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Export.Txt
{
    /// <summary>
    /// Represents structure of .txt document
    /// </summary>
    public class SimpleTxtDocumentBuilder : ITxtDocumentBuilder
    {
        /// <summary>
        /// Current document content
        /// </summary>
        private readonly List<string> _text;

        public SimpleTxtDocumentBuilder()
        {
            _text = new List<string>();
        }

        /// <summary>
        /// Writes document content to the given stream
        /// </summary>
        /// <param name="stream">Stream to write</param>
        public void ToStream(Stream stream)
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
            {
                foreach (var item in _text)
                {
                    writer.WriteLine(item);
                }

                writer.Flush();
            }
        }

        /// <summary>
        /// Adds string content as next line of the document
        /// </summary>
        /// <param name="text">Content to add</param>
        public void AddString(string text)
        {
            _text.Add(text);
        }
    }
}
