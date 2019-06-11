using Data;
using Export.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export
{
    class TestPdf
    {
        public static void Test()
        {
            new ToPdf<Item>().Export(new Item(42, DateTime.Now.ToString(), 1000));
        }
    }
}
