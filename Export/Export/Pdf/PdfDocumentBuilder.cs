using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace Export.Pdf
{
    /// <summary>
    /// Represents structure of .pdf document
    /// </summary>
    public class PdfDocumentBuilder : IPdfDocumentBuilder
    {
        private static readonly (float Width, float Height) _defaultCell = (100, 30);

        private static readonly (PdfStandardFont Name, float Size) _defaultFont = (PdfStandardFont.Helvetica, 10);

        private PdfFont Font
        {
            get
            {
                if (_document == null)
                {
                    throw new ApplicationException($"{nameof(_document)} is null");
                }

                var font = _document.AddFont(_defaultFont.Name);

                font.Size = _defaultFont.Size;

                return font;
            }
        }

        private static float Margin => 20;

        private float TableHeight
        {
            get
            {
                if (_state == null)
                {
                    throw new ApplicationException($"{nameof(_state)} is null");
                }

                return _state.Count * _defaultCell.Height;
            }
        }

        private float TableWidth
        {
            get
            {
                if (_state == null)
                {
                    throw new ApplicationException(nameof(_state));
                }

                return TotalColumns * _defaultCell.Width;
            }
        }

        /// <summary>
        /// Resulting document
        /// </summary>
        private PdfDocument _document;

        /// <summary>
        /// Working page (single one at the moment)
        /// </summary>
        private PdfPage Page
        {
            get
            {
                if (_document == null)
                {
                    throw new ApplicationException($"{nameof(_document)} is null.");
                }

                if (_document.Pages.Count == 0)
                {
                    throw new ApplicationException($"{nameof(_document)} contains 0 pages.");
                }

                return _document.Pages[0];
            }
        }

        /// <summary>
        /// Current document content
        /// </summary>
        private readonly List<string[]> _state;

        /// <summary>
        /// Table width 
        /// </summary>
        public int TotalColumns { get; }

        /// <summary>
        /// PdfDocumentBuilder constructor
        /// </summary>
        /// <param name="columns">Table width</param>
        public PdfDocumentBuilder(int columns)
        {
            if (columns < 0)
            {
                throw new ArgumentException($"Argument {nameof(columns)} should have positive value.");
            }

            TotalColumns = columns;
            _state = new List<string[]>();
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
                    $"that equals to value of {nameof(TotalColumns)} ({TotalColumns}).");
            }

            _state.Add(values);
        }

        /// <summary>
        /// Writes pdf document content to the given stream
        /// </summary>
        /// <param name="stream">Stream to write</param>
        public void ToStream(Stream stream)
        {
            _document = CreateSinglePageDocument(TableWidth, TableHeight, Margin);
            DrawTable(_state, Page, Font, _defaultCell);

            _document.Save(stream);
            _document.Close();
        }

        #region private methods

        /// <summary>
        /// Creates single-page document that have enough of space (A4 is minimum page size)
        /// on page's surface to place table containing current state
        /// </summary>
        /// <param name="width">Page width</param>
        /// <param name="height">Page height</param>
        /// <param name="margin">Page margin</param>
        /// <returns>Single page document</returns>
        private PdfDocument CreateSinglePageDocument(float width, float height, float margin)
        {
            var doc = new PdfDocument();

            (float Width, float Height) pageMinSize = (PdfCustomPageSize.A4.Width, PdfCustomPageSize.A4.Height);
            (float Width, float Height) pageRequiredSize = (width + 2 * margin, height + 2 * margin);

            float resultingHeight = Math.Max(pageMinSize.Height, pageRequiredSize.Height);
            float resultingWidth = Math.Max(pageMinSize.Width, pageRequiredSize.Width);
            
            PdfPageOrientation orientation =
                (resultingWidth > resultingHeight)
                ? PdfPageOrientation.Landscape
                : PdfPageOrientation.Portrait;

            doc.AddPage(
                new PdfCustomPageSize(resultingWidth, resultingHeight),
                new PdfMargins(margin),
                orientation);

            return doc;
        }

        /// <summary>
        /// Draws table containing data
        /// </summary>
        /// <param name="state">Data to print</param>
        /// <param name="page">Target page</param>
        /// <param name="font">Page font</param>
        /// <param name="cell">Cell size</param>
        private void DrawTable(List<string[]> state, PdfPage page, PdfFont font, (float Width, float Height) cell)
        {
            float currentTopPosition = 0;

            for (int i = 0; i < state.Count; i++)
            {
                float currentLeftPosition = 0;

                for (int j = 0; j < state[i].Length; j++)
                {
                    DrawCell(page, state[i][j], currentLeftPosition, currentTopPosition,
                        cell.Width, cell.Height, font);

                    currentLeftPosition += cell.Width;
                }

                currentTopPosition += cell.Height;
            }
        }

        private void DrawCell(PdfPage page, string content, float x, float y, 
            float width, float height, PdfFont font)
        {
            page.Add(new PdfTextElement(x, y, width, height, content, font));
            page.Add(new PdfRectangleElement(x, y, width, height));
        }

        #endregion
    }
}

