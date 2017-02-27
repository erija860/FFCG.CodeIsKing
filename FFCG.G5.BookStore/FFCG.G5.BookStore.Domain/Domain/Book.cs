namespace FFCG.G5.BookStore.Domain.Domain
{
    public class Book
    {
        public Book(string name, int id, decimal price)
        {
            Name = name;
            Id = id;
            Price = price;
        }

        public string Name { get; }
        public int Id { get; }
        public decimal Price { get; }
    }
}