using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Export.Base;

namespace Export.Txt
{
    public interface ITxtDocumentBuilder : IDocumentBuilder
    {
        void AddString(string text);
    }

}
