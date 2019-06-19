using Export.Base;

namespace Export
{
    public interface IDocumentGeneratorFactory
    {
        IDocumentGenerator<TContent> Create<TContent>(DocumentType documentType);
    }

}
