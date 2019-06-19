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

        private readonly List<(int rowIndex, int columnIndex, string value)> _text;

        public XlsxDocumentBuilder()
        {
            _text = new List<(int rowIndex, int columnIndex, string value)>();
        }

        public void ToStream(Stream stream)
        {
            using (var workbook = new XLWorkbook()) 
            {
                var worksheet = workbook.Worksheets.Add("List_1");

                //int row = 0;
                //for (int i = 1; i < _text.Count - 1; i++)
                //{
                //    for (int j = 1; j <= i; j++)
                //    {
                //        int colum = 0;
                //        worksheet.Cell(i, j).Value = _text[row, colum];
                //        colum++;
                //        j++;
                //        worksheet.Cell(i, j).Value = _text[row, colum];
                //        row++;
                //    }
                //}

                for (int i = 0; i < _text.Count; i++)
                {
                        worksheet.Cell(_text[i].rowIndex + 1, _text[i].columnIndex + 1).Value = _text[i].value;
                }

                workbook.SaveAs(stream);
            }
        }

        public void SetCellValue(int rowIndex, int columnIndex, string value)
        {
            //_text[rowIndex, columnIndex] = value;
            _text.Add((rowIndex, columnIndex, value));

        }

    }
}
