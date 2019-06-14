using Export.DataStructures;
using Export.Txt;
using System;
using System.Collections.Generic;
using System.IO;

namespace Export
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            using (FileStream file = File.Create("test.txt"))
            {
                PersonsSimpleTxtDocumentGenerator docGen = new PersonsSimpleTxtDocumentGenerator(new SimpleTxtDocumentBuilder(),
                    new PersonsTxtDocumentContentMapper());

                docGen.Generate(file, new List<Person>
                {
                    new Person
                    {
                        Name = "user 1",
                        Surname = "test 1"
                    },
                    new Person
                    {
                        Name = "user 2",
                        Surname = "test 2"
                    }
                });
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
