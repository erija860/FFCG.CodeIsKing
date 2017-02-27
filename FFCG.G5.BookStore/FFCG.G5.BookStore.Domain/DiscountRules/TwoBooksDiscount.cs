using System.Collections.Generic;
using FFCG.G5.BookStore.Domain.Domain;

namespace FFCG.G5.BookStore.Domain.DiscountRules
{
    public class TwoBooksDiscount : IDiscountRule
    {
        public decimal DiscountPercentage => 5M;
        public bool IsApplicable(List<Book> booksToCheck) => booksToCheck.Count == 2;
    }
}