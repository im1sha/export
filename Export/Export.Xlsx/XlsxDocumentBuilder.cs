using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;

namespace Export.Xlsx
{
    public class XlsxDocumentBuilder : IXlsxDocumentBuilder
    {
        private readonly List<(int rowIndex, int columnIndex, string value)> content;

        public XlsxDocumentBuilder()
        {
            content = new List<(int rowIndex, int columnIndex, string value)>();
        }

        public void ToStream(Stream stream)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("List_1");

                for (int i = 0; i < content.Count; i++)
                {
                    worksheet.Cell(content[i].rowIndex + 1, content[i].columnIndex + 1).Value = content[i].value;
                }

                workbook.SaveAs(stream);
            }
        }

        public void SetCellValue(int rowIndex, int columnIndex, string value)
        {
            content.Add((rowIndex, columnIndex, value));
        }
    }
}
