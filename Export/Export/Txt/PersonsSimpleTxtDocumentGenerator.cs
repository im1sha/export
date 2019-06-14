using Export.Base;
using Export.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Txt
{
    public class PersonsSimpleTxtDocumentGenerator : DocumentGenerator<ITxtDocumentBuilder, IEnumerable<Person>>
    {
        public PersonsSimpleTxtDocumentGenerator(ITxtDocumentBuilder documentBuilder,
            IDocumentContentMapper<ITxtDocumentBuilder, IEnumerable<Person>> documentContentMapper) : base(
            documentBuilder, documentContentMapper)
        {
        }
    }
}
