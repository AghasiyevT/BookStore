using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Events.Book;

public class BookStockUpdatedDomainEvent : DomainEvent
{
    public BookId BookId { get; }
    public int NewStockQuantity { get; }

    public BookStockUpdatedDomainEvent(BookId bookId, int newStockQuantity)
    {
        BookId = bookId;
        NewStockQuantity = newStockQuantity;
    }
}
