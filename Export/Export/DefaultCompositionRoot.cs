using Export.Base;
using Export.DataStructures;
using Export.Pdf;
using Export.Xlsx;
using System;
using System.Collections.Generic;

namespace Export
{
    public class DefaultCompositionRoot : ICompositionRoot
    {
        public object Resolve(Type type)
        {
            if (type == typeof(DocumentGenerator<IPdfDocumentBuilder, IEnumerable<Person>>))
            {
                return new PersonsPdfDocumentGenerator(
                    new PdfDocumentBuilder(2),
                    new PersonsPdfDocumentContentMapper());
            }
            else if (type == typeof(DocumentGenerator<IXlsxDocumentBuilder, IEnumerable<Person>>))
            {
                return new XlsxDocumentGenerator(
                  new XlsxDocumentBuilder(),
                  new XlsxDocumentContentMapper());
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
