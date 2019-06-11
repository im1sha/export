namespace Data
{
    public class Item
    {
        public Item(int id, string name, decimal price)
        {
            Id = id;
            Price = price;
            Name = name;
        }

        public int Id { get; }

        public decimal Price { get; }

        public string Name { get; }

    }
}
