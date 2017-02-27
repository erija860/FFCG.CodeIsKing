using System;
using System.Collections.Generic;

namespace FFCG.G5.BookStore
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

        public decimal GetPrice() => _priceCalculator.GetPrice(_books);
    }

    public class Book
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal Price { get; set; }
    }

    public interface IPriceCalculator
    {
        decimal GetPrice(List<Book> books);
    }

    public class PriceCalculator : IPriceCalculator
    {
        public List<IDiscountRule> DiscountRules;

        public decimal GetPrice(List<Book> books)
        {
            return 1;
        }
    }

    public interface IDiscountRule
    {
        bool IsApplicable();
    }

    public class TwoBooksDiscount : IDiscountRule
    {
        public bool IsApplicable()
        {
            throw new NotImplementedException();
        }
    }
}