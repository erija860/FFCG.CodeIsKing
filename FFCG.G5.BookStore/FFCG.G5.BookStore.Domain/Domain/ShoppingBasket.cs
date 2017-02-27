using System.Collections.Generic;
using FFCG.G5.BookStore.Domain.PriceCalculation;

namespace FFCG.G5.BookStore.Domain.Domain
{
    public class ShoppingBasket
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly IPriceCalculator _priceCalculator;

        public ShoppingBasket(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetBooks() => _books;

        public decimal GetPrice() => _priceCalculator.GetPrice(_books);
    }
}