using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Export.Xlsx;

namespace Export
{
    public class TestXlsx
    {
        public static void TestForXlsx()
        {
            IEnumerable<Person> list = new List<Person>()
            {
                new Person ( "1",  "2" ),
                new Person ( "3",  "4" ),
                new Person ( "5",  "6" ),
                new Person ( "7",  "8" ),         
            };

            var forXlsx = new ToXlsx();

            forXlsx.Export(list);
        }
    }
}
