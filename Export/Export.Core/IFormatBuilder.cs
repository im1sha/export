namespace Export.Core
{
    public interface IFormatBuilder<T>
    {
        void Export(T item);
    }
}
