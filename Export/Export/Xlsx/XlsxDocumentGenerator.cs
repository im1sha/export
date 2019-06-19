using Export.Base;
using Export.DataStructures;
using System.Collections.Generic;

namespace Export.Xlsx
{
    public class XlsxDocumentGenerator: DocumentGenerator<IXlsxDocumentBuilder, IEnumerable<Person>>
    {
        public XlsxDocumentGenerator(IXlsxDocumentBuilder documentBuilder,
            IDocumentContentMapper<IXlsxDocumentBuilder, IEnumerable<Person>> documentContentMapper) : base(
            documentBuilder, documentContentMapper)
        {
        }
    }
}
