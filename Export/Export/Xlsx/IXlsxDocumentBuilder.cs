using Export.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Xlsx
{
    public interface IXlsxDocumentBuilder: IDocumentBuilder
    {
        // Xlsx document specific methods
        void SetCellValue(int rowIndex, int columnIndex, string value);
      
    }


}
