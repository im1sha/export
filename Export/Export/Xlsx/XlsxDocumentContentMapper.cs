using Export.Base;
using Export.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Xlsx
{ 
    public class XlsxDocumentContentMapper: IDocumentContentMapper<IXlsxDocumentBuilder, IEnumerable<Person>>
    {
        public void MapContent(IXlsxDocumentBuilder documentBuilder, IEnumerable<Person> content)
        {
            foreach (var person in content)
            {
                //documentBuilder.AddString($"{person.Name} {person.Surname}");
                documentBuilder.SetCellValue(1,1, person.Name);
            }
        }
    }
}
