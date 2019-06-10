using Data;
using Export.Pdf;
using Export.Xlsx;
using System;

namespace Export
{
    internal class EntryPoint
    {
        private static readonly ToPdf<Item> _toPdf = new ToPdf<Item>();

        private static readonly ToXlsx<Item> _toXlsx = new ToXlsx<Item>();

        private static void Main(string[] args)
        {
            ConvertToPdf(new Item(42, DateTime.Now.ToString(), 1000));
        }

        private static void ConvertToXslx(Item item)
        {
            _toXlsx.Export(item);
        }

        private static void ConvertToPdf(Item item)
        {
            _toPdf.Export(item);
        }

    }
}
