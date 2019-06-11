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
    public class ToXlsx : IFormatBuilder2
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

        public void Export2<T>(T item) where T : IEnumerable<Person>
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

                //for (int i = 0; i <= item.Count -1; i++)
                //{
                //    int row = 1;
                //    int colum = 1;
                //    worksheet.Cell(row, colum).Value = item[i].FirstName;
                //    colum++;
                //    worksheet.Cell(row, colum).Value = item[i].LastName;
                //    row++;
                //}

            }
        }

        ////public Stream ToStream(List<Person> item)
        ////{
        ////    using (Stream stream = new FileStream())
        ////    {

        ////    }

        ////}
    }
}
