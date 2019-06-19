using ClosedXML.Excel;
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
        //private readonly List<string> _text;

        private readonly string[,] _text;

        public XlsxDocumentBuilder()
        {
            _text = new string[2,2];
        }

        public void ToStream(Stream stream)
        {
            using (var workbook = new XLWorkbook()) 
            {
                var worksheet = workbook.Worksheets.Add("List_1");

                int row = 0;
                for (int i = 1; i < _text.Length - 1; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        int colum = 0;
                        worksheet.Cell(i, j).Value = _text[row, colum];
                        colum++;
                        j++;
                        worksheet.Cell(i, j).Value = _text[row, colum];
                        row++;
                    }
                }

                workbook.SaveAs(stream);
            }
        }

        public void SetCellValue(int rowIndex, int columnIndex, string value)
        {
            _text[rowIndex, columnIndex] = value;
        }

    }
}
