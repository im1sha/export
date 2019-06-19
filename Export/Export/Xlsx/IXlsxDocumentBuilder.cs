using Export.Base;

namespace Export.Xlsx
{
    public interface IXlsxDocumentBuilder: IDocumentBuilder
    {
        void SetCellValue(int rowIndex, int columnIndex, string value);
    }
}
