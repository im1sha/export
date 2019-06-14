using Export.Base;
using Export.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Txt
{
    public class PersonsTxtDocumentContentMapper : IDocumentContentMapper<ITxtDocumentBuilder, IEnumerable<Person>>
    {
        public void MapContent(ITxtDocumentBuilder documentBuilder, IEnumerable<Person> content)
        {
            foreach (var person in content)
                documentBuilder.AddString($"{person.Name} {person.Surname}");
        }
    }
}
