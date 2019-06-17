using Export.Base;
using Export.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
