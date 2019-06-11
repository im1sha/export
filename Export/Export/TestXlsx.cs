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
                new Person ( "Kirill",  "Boika" ),
                new Person ( "1",  "4" ),
                new Person ( "2",  "5" ),
                new Person ( "3",  "6" ),         
            };

            var fonXlsx = new ToXlsx();

            //fonXlsx.Export2(list);
        }
    }
}
