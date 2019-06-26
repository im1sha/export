using DataStructures;
using Export;
using Export.Base;
using Export.Pdf;
using Export.Txt;
using Export.Xlsx;
using NUnit.Framework;
using System.Collections.Generic;

#region vs2019hotkeys
//Debug All Tests
//Ctrl+R, Ctrl+A
//Run All Tests
//Ctrl+R, A
#endregion

namespace Test
{
    public abstract class DefaultDocumentGeneratorFactoryTest<TContent, TBuilder> 
        where TBuilder : class, IDocumentBuilder
    {
        private static readonly IDocumentGeneratorFactory _factory = new DefaultDocumentGeneratorFactory();

        private static bool IsGeneratorMatchDocumentType(DocumentType documentType)
        {
            return _factory.Create<TContent>(documentType) is DocumentGenerator<TBuilder, TContent>;
        }

        protected static void CheckMatch(DocumentType documentType, bool expected)
        {
            Assert.AreEqual(IsGeneratorMatchDocumentType(documentType), expected);
        }

        public abstract void CheckIfMatch(DocumentType documentType);
        public abstract void CheckIfNotMatch(DocumentType documentType);
    }

    [TestFixture(typeof(IEnumerable<Person>), typeof(IPdfDocumentBuilder))]
    public class DefaultDocumentGeneratorFactoryPdfTest<TContent, TBuilder> :
        DefaultDocumentGeneratorFactoryTest<TContent, TBuilder> 
        where TBuilder : class, IDocumentBuilder
    {
        [TestCase(DocumentType.Pdf)]
        public override void CheckIfMatch(DocumentType documentType)
        {
            CheckMatch(documentType, true);
        }

        [TestCase(DocumentType.Xlsx)]
        [TestCase(DocumentType.Txt)]
        public override void CheckIfNotMatch(DocumentType documentType)
        {
            CheckMatch(documentType, false);
        }
    }

    [TestFixture(typeof(IEnumerable<Person>), typeof(IXlsxDocumentBuilder))]
    public class DefaultDocumentGeneratorFactoryXlsxTest<TContent, TBuilder> : 
        DefaultDocumentGeneratorFactoryTest<TContent, TBuilder> 
        where TBuilder : class, IDocumentBuilder
    {
        [TestCase(DocumentType.Xlsx)]
        public override void CheckIfMatch(DocumentType documentType)
        {
            CheckMatch(documentType, true);
        }

        [TestCase(DocumentType.Pdf)]
        [TestCase(DocumentType.Txt)]
        public override void CheckIfNotMatch(DocumentType documentType)
        {
            CheckMatch(documentType, false);
        }
    }


    [TestFixture(typeof(IEnumerable<Person>), typeof(ITxtDocumentBuilder))]
    public class DefaultDocumentGeneratorFactoryTxtTest<TContent, TBuilder> :
        DefaultDocumentGeneratorFactoryTest<TContent, TBuilder> 
        where TBuilder : class, IDocumentBuilder
    {
        [TestCase(DocumentType.Txt)]
        public override void CheckIfMatch(DocumentType documentType)
        {
            CheckMatch(documentType, true);
        }

        [TestCase(DocumentType.Pdf)]
        [TestCase(DocumentType.Xlsx)]
        public override void CheckIfNotMatch(DocumentType documentType)
        {
            CheckMatch(documentType, false);
        }
    }
}

