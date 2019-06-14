using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Export
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class SimpleTxtDocumentBuilder : ITxtDocumentBuilder
    {
        private readonly List<string> _text;

        public SimpleTxtDocumentBuilder()
        {
            _text = new List<string>();
        }

        public void ToStream(Stream stream)
        {
            using (var writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
            {
                foreach (var item in _text)
                    writer.WriteLine(item);

                writer.Flush();
            }
        }

        public void AddString(string text)
        {
            _text.Add(text);
        }
    }

    public class PersonsTxtDocumentContentMapper : IDocumentContentMapper<ITxtDocumentBuilder, IEnumerable<Person>>
    {
        public void MapContent(ITxtDocumentBuilder documentBuilder, IEnumerable<Person> content)
        {
            foreach (var person in content)
                documentBuilder.AddString($"{person.Name} {person.Surname}");
        }
    }

    public class PersonsSimpleTxtDocumentGenerator : DocumentGenerator<ITxtDocumentBuilder, IEnumerable<Person>>
    {
        public PersonsSimpleTxtDocumentGenerator(ITxtDocumentBuilder documentBuilder,
            IDocumentContentMapper<ITxtDocumentBuilder, IEnumerable<Person>> documentContentMapper) : base(
            documentBuilder, documentContentMapper)
        {
        }
    }
}