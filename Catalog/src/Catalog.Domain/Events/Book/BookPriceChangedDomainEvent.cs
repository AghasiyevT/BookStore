using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Events.Book;

public class BookPriceChangedDomainEvent : DomainEvent
{
    public BookId BookId { get; }
    public decimal NewPrice { get; }

    public BookPriceChangedDomainEvent(BookId bookId, decimal newPrice)
    {
        BookId = bookId;
        NewPrice = newPrice;
    }
}
