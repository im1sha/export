using Export.Pdf;
using System.IO;

namespace Export
{
    internal class TestPdf
    {
        public static void Test()
        {
            using (FileStream str = new FileStream("EXPORT.pdf", FileMode.OpenOrCreate))
            {
                new ToPdf().ToStream(str);
            }
        }
    }
}
