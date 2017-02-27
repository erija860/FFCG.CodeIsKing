using System.Collections.Generic;
using FFCG.G5.BookStore.Domain.Domain;

namespace FFCG.G5.BookStore.Domain.DiscountRules
{
    public interface IDiscountRule
    {
        decimal DiscountPercentage { get; }
        bool IsApplicable(List<Book> booksToCheck);
    }
}