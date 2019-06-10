using System.IO;
using Export.Core;
using SelectPdf;
using System.Reflection;

namespace Export.Pdf
{
    public class ToPdf<T>: IFormatBuilder<T>
    {
        private const int LINE_HEIGHT = 50;

        private const string FILE_NAME = "EXPORT.pdf";

        public void Export(T item)
        {
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.AddPage();

            PdfFont font = doc.AddFont(PdfStandardFont.Helvetica);
            font.Size = 20;

            var props = item.GetType().GetProperties();

            for (int i = 0; i < props.Length; i++)
            {      
                PdfTextElement elem = new PdfTextElement(0, i * LINE_HEIGHT, props[i].GetValue(item).ToString(), font);
                var cell = new PdfRectangleElement(0, i * LINE_HEIGHT, page.PageSize.Width / 2, LINE_HEIGHT);
                page.Add(cell);
                page.Add(elem);
            }

            doc.Save(FILE_NAME);
            doc.Close();
        }
    }
}
