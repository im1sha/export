using DataStructures;
using Export.Base;
using System.Collections.Generic;

namespace Export.Xlsx
{
    public class XlsxDocumentContentMapper : IDocumentContentMapper<IXlsxDocumentBuilder, IEnumerable<Person>>
    {
        public void MapContent(IXlsxDocumentBuilder documentBuilder, IEnumerable<Person> content)
        {
            int row = 0;
            foreach (var i in content)
            {
                int colum = 0;
                documentBuilder.SetCellValue(row, colum, i.Name);
                colum++;
                documentBuilder.SetCellValue(row, colum, i.Surname);
                row++;
            }
        }
    }
}
