using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Export;
using System.IO;
using Export.Core;
using Data;

namespace Export.Xlsx
{
    public class ToXlsx : IFormatBuilder
    {
        public void Export<T>(T item) where T : IEnumerable<Person>
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("List_1");

                int row = 1;
                foreach (var i in item)
                {
                    int colum = 1;
                    worksheet.Cell(row, colum).Value = i.FirstName;
                    colum++;
                    worksheet.Cell(row, colum).Value = i.LastName;
                    row++;
                }
                workbook.SaveAs("Person.xlsx");
            }
        }

        public void ToStream(Stream stream)
        {
            using (stream = new FileStream("Person.xlsx", FileMode.OpenOrCreate))
            {
            }
        }
    }
}
