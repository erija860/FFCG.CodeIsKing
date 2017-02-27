using System.Collections.Generic;
using FFCG.G5.BookStore.Domain.Domain;

namespace FFCG.G5.BookStore.Domain.DiscountRules
{
    public class FiveBooksDiscount : IDiscountRule
    {
        public decimal DiscountPercentage => 25M;
        public bool IsApplicable(List<Book> booksToCheck) => booksToCheck.Count == 5;
    }
}