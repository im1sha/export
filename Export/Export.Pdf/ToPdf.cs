using Export.Core;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Export.Pdf
{
    
    public class ToPdf : IPdfFormatBuilder
    {
        private readonly List<(int x, int y, string value)> _state;

        private const int CELL_HEIGHT = 30;
        private const int CELL_WIDTH = 50;
        private const PdfStandardFont FONT = PdfStandardFont.Helvetica;
        private const int FONT_SIZE = 20;
        private const int DEFAULT_MARGIN = 10;


        public ToPdf()
        {
            _state = new List<(int x, int y, string value)>();
        }


        /// <summary>
        /// Returns page containing table
        /// Margin: DEFAULT_MARGIN
        /// 
        /// </summary>
        private PdfDocument CreateDocument(List<(int x, int y, string value)> state)
        {
            PdfDocument result = new PdfDocument();

            int totalX = state.Max(val => val.x);
            int totalY = state.Max(val => val.y);

            int height = totalX * CELL_HEIGHT;
            int width = totalY * CELL_WIDTH;

            PdfPage page = result.AddPage(
                new PdfCustomPageSize(width + DEFAULT_MARGIN * 2, height + DEFAULT_MARGIN * 2),
                new PdfMargins(DEFAULT_MARGIN));

            PdfFont font = result.AddFont(FONT);
            font.Size = FONT_SIZE;


            for (int i = 0; i < _state.Count; i++)
            {
                int left = _state[i].x * CELL_WIDTH + DEFAULT_MARGIN;
                int top = _state[i].y * CELL_HEIGHT + DEFAULT_MARGIN;

                PdfTextElement elem = new PdfTextElement(left ,top , _state[i].value, font);

                PdfRectangleElement cell = new PdfRectangleElement(left, top, CELL_WIDTH, CELL_HEIGHT);
                page.Add(cell);
                page.Add(elem);
            }

            return result;
        }


        private void DrawTable(int xSize, int ySize, string[,] values)
        {
            if (xSize < 0 || ySize < 0)
            {
                throw new ArgumentException();
            }

            throw new NotImplementedException();
        }

        public void SetCellValue(int x, int y, string value)
        {
            _state.Add((x, y, value));
        }

        public void ToStream(Stream stream)
        {
            PdfDocument doc = CreateDocument(_state);
            doc.Save(stream);
            doc.Close();
        }
    }
}
