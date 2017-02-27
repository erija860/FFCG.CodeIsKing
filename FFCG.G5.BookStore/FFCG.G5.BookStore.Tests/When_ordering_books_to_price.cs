using System.Collections.Generic;
using FFCG.G5.BookStore.Domain.DiscountRules;
using FFCG.G5.BookStore.Domain.Domain;
using FFCG.G5.BookStore.Domain.PriceCalculation;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.BookStore.Tests
{
    [TestFixture]
    public class When_ordering_books_to_price
    {
        private HarryPotterBooksPriceCalculator _harryPotterBooksPriceCalculator;
        private List<List<Book>> _orderedBooks;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _harryPotterBooksPriceCalculator = new HarryPotterBooksPriceCalculator(new List<IDiscountRule>());
            _orderedBooks =
                _harryPotterBooksPriceCalculator.OrderBooksToPrice(new List<Book>
                {
                    new Book("Harry Potter", 1, 8),
                    new Book("Harry Potter", 2, 8),
                    new Book("Harry Potter", 3, 8),
                    new Book("Harry Potter", 2, 8),
                    new Book("Harry Potter", 1, 8),
                    new Book("Harry Potter", 2, 8)
                });
        }

        [Test]
        public void Should_be_correct_count()
        {
            _orderedBooks.Count.Should().Be(3);
        }
    }
}