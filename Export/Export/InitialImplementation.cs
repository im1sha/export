using System;
using System.Collections.Generic;
using System.IO;

namespace Demo
{
    /// <summary>
    /// Implementation for .TXT format
    /// </summary>
    public class InitialImplementation
    {
        public static void Start()
        {
            Person[] items2 = new Employee[] {
                new Employee(11.ToString(), 22.ToString()),
                new Employee(33.ToString(), 44.ToString()),
                new Employee(55.ToString(), 66.ToString())
            };

            Facade.SavePersonsToTxtFile(items2, "FILE.txt");
        }
    }

    public static class Facade
    {
        public static void SavePersonsToTxtFile(IEnumerable<IPerson> persons, string path)
        {
            new PersonToTxtMapper<TxtFormatBuilder, IPerson>(
                new TxtDocumentGenerator<TxtFormatBuilder>(path),
                new TxtFormatBuilder()).Save(persons);
        }
    }

    #region iformatbuilder support

    public interface IFormatBuilder { void ToStream(Stream stream); }

    public interface ITxtFormatBuilder : IFormatBuilder { void AddString(string str); }

    public class TxtFormatBuilder : ITxtFormatBuilder
    {
        private readonly List<string> _state;

        public TxtFormatBuilder()
        {
            _state = new List<string>();
        }

        public void AddString(string str)
        {
            _state.Add(str);
        }

        public void ToStream(Stream stream)
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                foreach (string item in _state)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }

    #endregion


    #region idocumentgenerator support

    public interface IDocumentGenerator<T> where T : IFormatBuilder { void Generate(T builder); }

    public interface ITxtDocumentGenerator<T> : IDocumentGenerator<T> where T : ITxtFormatBuilder { }

    public class TxtDocumentGenerator<T> : ITxtDocumentGenerator<T>
        where T : ITxtFormatBuilder
    {
        private readonly string _path;
        public TxtDocumentGenerator(string path)
        {
            _path = path;
        }

        public void Generate(T builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            using (FileStream s = new FileStream(_path, FileMode.Create))
            {
                builder.ToStream(s);
            }
        }
    }

    #endregion


    #region contentmapper

    public abstract class ContentMapper<TBuilder, TContent>
        where TBuilder : class, IFormatBuilder
        where TContent : class
    {
        protected IDocumentGenerator<TBuilder> _documentGenerator;
        protected TBuilder _builder;

        public ContentMapper(IDocumentGenerator<TBuilder> documentGenerator, TBuilder builder)
        {
            _documentGenerator = documentGenerator ?? throw new ArgumentNullException(nameof(documentGenerator));
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public abstract void Save(IEnumerable<TContent> content);
    }

    public class PersonToTxtMapper<TBuilder, TContent> : ContentMapper<TBuilder, TContent>
        where TBuilder : class, ITxtFormatBuilder
        where TContent : class, IPerson
    {
        public PersonToTxtMapper(ITxtDocumentGenerator<TBuilder> documentGenerator, TBuilder builder) :
            base(documentGenerator, builder)
        { }

        public override void Save(IEnumerable<TContent> content)
        {
            foreach (TContent item in content)
            {
                _builder.AddString(item.FirstName + " " + item.LastName);
            }
            _documentGenerator.Generate(_builder);
        }
    }
    #endregion


    #region IPerson 
    public interface IPerson { string FirstName { get; } string LastName { get; } }

    public class Person : IPerson
    {
        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Employee : Person
    {
        public Employee(string first, string last) : base(first, last)
        {

        }
    }
    #endregion
}
