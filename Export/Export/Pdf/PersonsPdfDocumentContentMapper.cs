using Export.Base;
using Export.DataStructures;
using System.Collections.Generic;

namespace Export.Pdf
{
    public class PersonsPdfDocumentContentMapper : IDocumentContentMapper<IPdfDocumentBuilder, IEnumerable<Person>>
    {
        /// <summary>
        /// Maps content represented as IEnumerable of <see cref="Person"/> to 
        /// pdf-document structure (<see cref="IPdfDocumentBuilder"/>)
        /// </summary>
        /// <param name="documentBuilder">Pdf-document structure representation</param>
        /// <param name="content">Content to map</param>
        public void MapContent(IPdfDocumentBuilder documentBuilder, IEnumerable<Person> content)
        {
            foreach (var person in content)
            {
                documentBuilder.AddRow(new string[] { person.Name, person.Surname });
            }
        }
    }
}
