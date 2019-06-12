using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export.Core
{
    public interface IPdfFormatBuilder: IFormatBuilder
    {
        void SetCellValue(int x, int y, string value);
    }
}
