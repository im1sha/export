using Export.Base;
using DataStructures;
using System.Collections.Generic;

namespace Export.Pdf
{
    /// <summary>
    /// Parses input
    /// </summary>
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
            documentBuilder.AddRow(new string[] { "Name", "Surname" });

            foreach (var person in content)
            {
                if (person == null)
                {
                    continue;
                }

                documentBuilder.AddRow(new string[] { person.Name ?? "", person.Surname ?? "" });
            }
        }
    }
}
