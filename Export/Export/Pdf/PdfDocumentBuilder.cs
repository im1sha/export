using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Export.Pdf
{
    /// <summary>
    /// Represents structure of .pdf document
    /// </summary>
    public class PdfDocumentBuilder : IPdfDocumentBuilder
    {
        /// <summary>
        /// Current document content
        /// </summary>
        private readonly List<string[]> _content;

        private const int CELL_HEIGHT = 30;
        private const int CELL_WIDTH = 50;
        private const PdfStandardFont FONT = PdfStandardFont.Helvetica;
        private const int FONT_SIZE = 20;
        private const int DEFAULT_MARGIN = 10;



        /// <summary>
        /// Table width 
        /// </summary>
        public int TotalColumns { get; }

        /// <summary>
        /// Text to place on the top of the table
        /// </summary>
        private readonly string[] _header;

        /// <summary>
        /// PdfDocumentBuilder constructor
        /// </summary>
        /// <param name="columns">Table width</param>
        /// <param name="header">Table header</param>
        public PdfDocumentBuilder(int columns, string[] header)
        {
            if (columns < 0)
            {
                throw new ArgumentException($"Argument {nameof(columns)} should have positive value.");
            }

            if (header == null)
            {
                throw new ArgumentNullException(nameof(header));

            }

            if (columns != header.Length)
            {
                throw new ArgumentException($"{nameof(columns)} should be equal to Length of {nameof(header)}");
            }

            TotalColumns = columns;
            _header = header;
            _content = new List<string[]>();
        }

        /// <summary>
        /// Appends row of cells to current document structure
        /// </summary> 
        /// <param name="values">Values to append</param>
        public void AddRow(string[] values)
        {
            if (values.Length != TotalColumns)
            {
                throw new ArgumentException($"{nameof(values)} should have length " +
                    $"that equals to value of {nameof(TotalColumns)}({TotalColumns}).");
            }

            _content.Add(values);
        }

        /// <summary>
        /// Writes pdf document content to the given stream
        /// </summary>
        /// <param name="stream">Stream to write</param>
        public void ToStream(Stream stream)
        {
            throw new NotImplementedException();

            //SelectPdf.PdfDocument doc = new SelectPdf.PdfDocument();
            //SelectPdf.PdfPage page = doc.AddPage();

            //SelectPdf.PdfFont font = doc.AddFont(SelectPdf.PdfStandardFont.Helvetica);
            //font.Size = 20;

            //SelectPdf.PdfTextElement text = new SelectPdf.PdfTextElement(50, 50, "Hello world!", font);
            //page.Add(text);

            //doc.Save("test.pdf");
            //doc.Close();


             

        }
    }
}


