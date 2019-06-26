using DataStructures;
using Export;
using Export.Base;
using Export.Pdf;
using Export.Xlsx;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Test
{
    [TestFixture()]
    public class ExportTests
    {
        private readonly IDocumentGeneratorFactory _factory = new DefaultDocumentGeneratorFactory();

        private static readonly Person[] _people = new Person[2] {
                new Person() { Name = "name", Surname = "surname" },
                new Person() { Name = "name2", Surname = "surname2" }
        };

        private static readonly  PdfDocumentBuilder _builder = new PdfDocumentBuilder();
        #region vs2019hotkeys
        //Debug All Tests
        //Ctrl+R, Ctrl+A
        //Run All Tests
        //Ctrl+R, A
        #endregion

        [TestCase(_builder, _people, DocumentType.Pdf )]

        public void Create<TBuilder, TContent>(TBuilder builder, TContent items, DocumentType outDocType)
            where TBuilder: class, IDocumentBuilder
        {
            var result = _factory.Create<TContent>(outDocType) is DocumentGenerator<TBuilder, TContent>;
            Assert.AreEqual(result, true);
        }

        [TestCase(42)]
        [TestCase("string")]
        [TestCase(double.Epsilon)]
        public void GenericTest<T>(T instance)
        {
            Trace.WriteLine(instance.GetType());
        }

        T Test<T>(T obj) where T : class, new()
        {
            return new T();
        }
    }

    

    //[TestFixture(typeof(int))]
    //[TestFixture(typeof(string))]
    //public class GenericTestFixture<T>
    //{
    //    [Test]
    //    public void TestType()
    //    {
    //        Assert.Pass($"The generic test type is {typeof(T)}");
    //    }
    //}
}
