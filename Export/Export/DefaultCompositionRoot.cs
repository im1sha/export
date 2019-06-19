﻿using Export.Base;
using Export.DataStructures;
using Export.Pdf;
using Export.Txt;
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
            else if (type == typeof(DocumentGenerator<ITxtDocumentBuilder, IEnumerable<Person>>))
            {
                return new PersonsSimpleTxtDocumentGenerator(
                    new SimpleTxtDocumentBuilder(),
                    new PersonsTxtDocumentContentMapper());
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
