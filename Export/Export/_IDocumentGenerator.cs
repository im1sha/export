//using System;
//using System.IO;

//namespace Export
//{
//    public interface ICompositionRoot
//    {
//        object Resolve(Type type);
//    }

//    public enum DocumentType
//    {
//        Xslx,
//        Pdf
//    }





//    public interface IXslxDocumentBuilder : IDocumentBuilder
//    {
//        void SetCellValue(int rowIndex, int columnIndex, string value);
//        // Xlsx document specific methods
//    }

//    public interface IPdfDocumentBuilder : IDocumentBuilder
//    {
//        // Pdf document specific methods
//    }




//    public interface IDocumentGeneratorFactory
//    {
//        IDocumentGenerator<TContent> Create<TContent>(DocumentType documentType);
//    }


//    public class DefaultDocumentGeneratorFactory : IDocumentGeneratorFactory
//    {
//        private readonly ICompositionRoot _compositionRoot;

//        public DefaultDocumentGeneratorFactory(ICompositionRoot compositionRoot)
//        {
//            _compositionRoot = compositionRoot ?? throw new ArgumentNullException(nameof(compositionRoot));
//        }

//        public IDocumentGenerator<TContent> Create<TContent>(DocumentType documentType)
//        {
//            switch (documentType)
//            {
//                case DocumentType.Xslx:
//                    return (IDocumentGenerator<TContent>)_compositionRoot.Resolve(
//                        typeof(DocumentGenerator<IXslxDocumentBuilder, TContent>));
//                case DocumentType.Pdf:
//                    return
// (IDocumentGenerator<TContent>)_compositionRoot.Resolve(
//     typeof(DocumentGenerator<IPdfDocumentBuilder, TContent>));
//                default:
//                    throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null);
//            }
//        }
//    }
//}