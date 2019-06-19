using Export;
using Export.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;

namespace Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            using (FileStream file = File.Create("test.pdf"))
            {
                DefaultDocumentGeneratorFactory factory = new DefaultDocumentGeneratorFactory(
                    new DefaultCompositionRoot());

                var docGen = factory.Create<IEnumerable<Person>>(DocumentType.Pdf);

                docGen.Generate(file, new List<Person>
                {
                    null,
                    new Person
                    {
                        Name = "user 1",
                        Surname = "test 1"
                    },
                    new Person
                    {
                        Name = null,
                        Surname = null
                    },
                    new Person
                    {
                        Name = "user 2",
                        Surname = "test 2"
                    }
                });
            }

            Console.WriteLine("Done");
        }
    }
}
