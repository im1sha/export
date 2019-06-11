using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Export.Xlsx;

namespace Export
{
    public class TestXlsx
    {
        public static void TestForXlsx()
        {
            IEnumerable<Person> list = new List<Person>()
            {
                new Person() { FirstName = "Kirill", LastName = "Boika" },
                new Person() { FirstName = "Mishail", LastName = "Ovchelupov" },
                new Person() { FirstName = "Anton", LastName = "Ivanov" },
                new Person() { FirstName = "Sergey", LastName = "Petorv" },
                new Person() { FirstName = "Pasha", LastName = "Xabibulin" },
                new Person() { FirstName = "Dima", LastName = "Kak-to-Tak" }
            };

            var fonXlsx = new ToXlsx();

            fonXlsx.Export2(list);
        }
    }
}
