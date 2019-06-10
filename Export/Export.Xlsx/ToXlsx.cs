using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Export;

namespace Export.Xlsx
{
    public class ToXlsx : IFormatBuilder
    {
        public void Export<T>(T item) where T : Person
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("List_1");
                worksheet.Cell("A1").Value = item.FirstName;
                worksheet.Cell("B1").Value = item.LastName;
                workbook.SaveAs("Person.xlsx");
            }
        }
    }
}
