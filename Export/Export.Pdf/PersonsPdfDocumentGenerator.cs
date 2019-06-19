using Export.Base;
using Export.DataStructures;
using System.Collections.Generic;

namespace Export.Pdf
{
    /// <summary>
    /// Generates content of type <see cref="Person"/> to .pdf-document using the given structure representation (<see cref="IPdfDocumentBuilder"/>)  
    /// </summary>
    public class PersonsPdfDocumentGenerator : DocumentGenerator<IPdfDocumentBuilder, IEnumerable<Person>>
    {
        public PersonsPdfDocumentGenerator(IPdfDocumentBuilder documentBuilder,
            IDocumentContentMapper<IPdfDocumentBuilder, IEnumerable<Person>> documentContentMapper) : base(
                documentBuilder, documentContentMapper)
        {
        }
    }
}
