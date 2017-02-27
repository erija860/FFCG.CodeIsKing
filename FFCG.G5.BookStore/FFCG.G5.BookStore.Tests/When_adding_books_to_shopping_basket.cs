using FakeItEasy;
using FFCG.G5.BookStore.Domain.Domain;
using FFCG.G5.BookStore.Domain.PriceCalculation;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G5.BookStore.Tests
{
    [TestFixture]
    public class When_adding_books_to_shopping_basket
    {
        private ShoppingBasket _shoppingBasket;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _shoppingBasket = new ShoppingBasket(A.Fake<IPriceCalculator>());
            _shoppingBasket.AddBook(new Book("testBook", 1, 10));
            _shoppingBasket.AddBook(new Book("testBook", 2, 10));
            _shoppingBasket.AddBook(new Book("testBook", 3, 10));
        }

        [Test]
        public void Books_should_have_been_added()
        {
            _shoppingBasket.GetBooks().Count.Should().Be(3);
        }
    }
}