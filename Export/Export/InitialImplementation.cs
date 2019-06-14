using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

    //using (FileStream s = new FileStream(_path, FileMode.Create)) { }


    public static class Facade
    {
        public static void SavePersonsToTxtFile(IEnumerable<IPerson> persons, string path)
        {
            throw new NotImplementedException(nameof(Facade));

            //PersonToTxtMapper<TxtFormatBuilder, IPerson> mapper = 
            //    new PersonToTxtMapper<TxtFormatBuilder, IPerson>();

            //mapper.Map(new TxtDocumentGenerator<TxtFormatBuilder>(path),
            //     new TxtFormatBuilder());

            //mapper.Export(persons);
        }
    }

    #region IFormatBuilder support

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
            using (StreamWriter writer = 
                new StreamWriter(stream, Encoding.UTF8, 4096, true /*!it's important to leave disposing to caller*/ ))
            {
                foreach (string item in _state)
                {
                    writer.WriteLine(item);
                }

                writer.Flush();
            }
        }
    }

    #endregion


    #region IDocumentGenerator support

    public interface IDocumentGenerator<TContent> { void Generate(Stream stream, TContent builder); }

    public class DocumentGenerator<TContent> : IDocumentGenerator<TContent> 
    {
        private readonly IContentMapper<IFormatBuilder, TContent> _mapper;
        private readonly IFormatBuilder _builder;

        public DocumentGenerator(IContentMapper<IFormatBuilder, TContent> mapper, ITxtFormatBuilder builder)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }
  
        public void Generate(Stream stream, TContent content)
        {
            _mapper.Map(_builder, content);
            _builder.ToStream(stream);
        }      
    }


    public class TxtDocumentGenerator<TContent> : DocumentGenerator<TContent>
    {
        private readonly IContentMapper<ITxtFormatBuilder, TContent> _mapper;
        private readonly ITxtFormatBuilder _builder;

        public TxtDocumentGenerator(IContentMapper<ITxtFormatBuilder, TContent> mapper,
            ITxtFormatBuilder builder)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

    }

    #endregion


    #region icontentmapper support

    public interface IContentMapper<TBuilder, TContent>
    {
        void Map(TBuilder builder, TContent content);
    }

    public class ContentMapper<TBuilder, TContent>  where TBuilder : class, IFormatBuilder
    {
        //protected IDocumentGenerator<TBuilder> _documentGenerator;
        //protected TBuilder _builder;


        //public override void Export(IEnumerable<TContent> content)
        //{
        //    foreach (TContent item in content)
        //    {
        //        _builder.AddString(item.FirstName + " " + item.LastName);
        //    }
        //    _documentGenerator.Generate(_builder);
        //}
        public void Map(TBuilder builder, TContent content)
        {
            foreach (TContent item in content)
            {
                _builder.AddString(item.FirstName + " " + item.LastName);
            }
            _documentGenerator.Generate(_builder);
        }

    }

    public class PersonToTxtMapper<TBuilder, TContent> : ContentMapper<TBuilder, TContent>
        where TBuilder : class, ITxtFormatBuilder
        where TContent : IPerson
    {
        public void Map(TBuilder documentGenerator, TBuilder builder)
        {
            if (!(documentGenerator is ITxtDocumentGenerator<TBuilder>))
            {
                throw new ArgumentException();
            }
            base.Map(documentGenerator, builder);
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
