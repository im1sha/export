using System;
using System.Collections.Generic;
using System.IO;

namespace Export
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var file = File.Create("test.txt");
            var docGen = new PersonsSimpleTxtDocumentGenerator(new SimpleTxtDocumentBuilder(),
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

            file.Dispose();

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
