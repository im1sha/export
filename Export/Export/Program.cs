using Export.DataStructures;
using Export.Pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace Export
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            using (FileStream file = File.Create("test.pdf"))
            {
                PersonsPdfDocumentGenerator docGen = new PersonsPdfDocumentGenerator(
                    new PdfDocumentBuilder(2),
                    new PersonsPdfDocumentContentMapper());

                docGen.Generate(file, new List<Person>
                {
                    new Person
                    {
                        Name = "user 1user 1user 1user 1user 1user 1user 1user 1user 1user 1user 1",
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
        }
    }
}
