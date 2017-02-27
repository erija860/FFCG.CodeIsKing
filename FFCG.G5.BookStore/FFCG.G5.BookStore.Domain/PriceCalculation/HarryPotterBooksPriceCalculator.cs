using System.Collections.Generic;
using System.Linq;
using FFCG.G5.BookStore.Domain.DiscountRules;
using FFCG.G5.BookStore.Domain.Domain;

namespace FFCG.G5.BookStore.Domain.PriceCalculation
{
    public class HarryPotterBooksPriceCalculator : IPriceCalculator
    {
        private readonly List<IDiscountRule> _discountRules;

        public HarryPotterBooksPriceCalculator(List<IDiscountRule> discountRules)
        {
            _discountRules = discountRules;
        }

        public decimal GetPrice(List<Book> books)
        {
            var groupings = OrderBooksToPrice(books);

            return groupings.Sum(grouping => GetPriceOfGroupedBooks(grouping));
        }

        public decimal GetPriceOfGroupedBooks(List<Book> booksToPrice)
        {
            var discountPercentage =
            (from discountRule in _discountRules
             where discountRule.IsApplicable(booksToPrice)
             select discountRule.DiscountPercentage).FirstOrDefault();

            var ordinaryTotalPrice = booksToPrice.Aggregate(0M, (current, book) => current + book.Price);

            return ordinaryTotalPrice * (1 - discountPercentage / 100);
        }

        public List<List<Book>> OrderBooksToPrice(List<Book> booksToPrice)
        {
            var groupsOfUniqueBooks = new List<List<Book>>();

            var groupings = booksToPrice.Where(b => b.Name.Equals("Harry Potter")).GroupBy(book => book.Id).ToList();

            var numberOfdifferentBooks = groupings.OrderByDescending(x => x.Count()).First().Count();

            for (var i = 0; i < numberOfdifferentBooks; i++)
                groupsOfUniqueBooks.Add(new List<Book>());

            foreach (var grouping in groupings)
            {
                var place = 0;
                foreach (var book in grouping)
                {
                    groupsOfUniqueBooks[place].Add(book);
                    place++;
                }
            }

            return groupsOfUniqueBooks;
        }
    }
}