using Export.Xlsx;
using Data;

namespace Export
{
    internal class EntryPoint
    {
        private static void Main(string[] args)
        {
            var person = new Person("Name", "LastName");

            var fonXlsx = new ToXlsx<Person>();

            fonXlsx.Export(person);

        }
    }
}
