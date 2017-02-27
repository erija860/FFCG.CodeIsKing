using System.Collections.Generic;
using FFCG.G5.BookStore.Domain.Domain;

namespace FFCG.G5.BookStore.Domain.PriceCalculation
{
    public interface IPriceCalculator
    {
        decimal GetPrice(List<Book> books);
    }
}