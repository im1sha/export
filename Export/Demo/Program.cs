using Export;
using DataStructures;
using System;
using System.Collections.Generic;
using System.IO;

namespace Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DefaultDocumentGeneratorFactory factory = new DefaultDocumentGeneratorFactory();

            var xlsxGenerator = factory.Create<IEnumerable<Person>>(DocumentType.Xlsx);
            var pdfGenerator = factory.Create<IEnumerable<Person>>(DocumentType.Pdf);
            var textGenerator = factory.Create<IEnumerable<Person>>(DocumentType.Txt);

            var people = new List<Person>() {
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
            };

            using (FileStream file = File.Create("test.xlsx"))
            {
                xlsxGenerator.Generate(file, people);
            }

            using (FileStream file = File.Create("test.pdf"))
            {
                pdfGenerator.Generate(file, people);
            }

            using (FileStream file = File.Create("test.txt"))
            {
                textGenerator.Generate(file, people);
            }

            Console.WriteLine("Done");
        }
    }
}
