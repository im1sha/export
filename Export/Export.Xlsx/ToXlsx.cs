using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Xlsx
{
    public class ToXlsx<T>
    {
        public void Export(T item)
        {
            using (var workbook = new XLWorkbook())
            { 
                var worksheet = workbook.Worksheets.Add("List_1");
                worksheet.Cell("A1").Value = "Hello";
                worksheet.Cell("A2").Value = item;
                workbook.SaveAs("Person.xlsx");
            }
        }
    }
}
