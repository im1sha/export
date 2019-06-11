using Data;
using Export.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export
{
    class TestPdf
    {
        public static void Test()
        {

            using (var str = new FileStream("EXPORT.pdf", FileMode.OpenOrCreate)) {
                new ToPdf().ToStream<Item>(new Item(42, DateTime.Now.ToString(), 1000),str );
            }
        }
    }
}
