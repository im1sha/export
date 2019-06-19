using Export.Base;
using Export.DataStructures;
using System.Collections.Generic;

namespace Export.Txt
{
    public class PersonsTxtDocumentContentMapper : IDocumentContentMapper<ITxtDocumentBuilder, IEnumerable<Person>>
    {
        /// <summary>
        /// Maps content represented as IEnumerable of <see cref="Person"/> to 
        /// txt-document structure (<see cref="ITxtDocumentBuilder"/>)
        /// </summary>
        /// <param name="documentBuilder">Document structure representation </param>
        /// <param name="content">Content to map</param>
        public void MapContent(ITxtDocumentBuilder documentBuilder, IEnumerable<Person> content)
        {
            foreach (var person in content)
            {
                documentBuilder.AddString($"{person.Name} {person.Surname}");
            }
        }
    }
}

