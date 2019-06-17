using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Xlsx
{
    public class XlsxDocumentBuilder : IXlsxDocumentBuilder
    {
        private readonly List<string> _text;

        public XlsxDocumentBuilder()
        {
            _text = new List<string>();
        }

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

        public void SetCellValue(int rowIndex, int columnIndex, string value)
        {
            throw new NotImplementedException();
        }

    }
}
