using Export.Base;
using DataStructures;
using System.Collections.Generic;

namespace Export.Txt
{
    /// <summary>
    /// Generates <see cref="Person"/> content to the .txt document using <see cref="ITxtDocumentBuilder"/>
    /// </summary>
    public class PersonsSimpleTxtDocumentGenerator : DocumentGenerator<ITxtDocumentBuilder, IEnumerable<Person>>
    {
        public PersonsSimpleTxtDocumentGenerator(ITxtDocumentBuilder documentBuilder,
            IDocumentContentMapper<ITxtDocumentBuilder, IEnumerable<Person>> documentContentMapper) : base(
            documentBuilder, documentContentMapper)
        {
        }
    }
}
