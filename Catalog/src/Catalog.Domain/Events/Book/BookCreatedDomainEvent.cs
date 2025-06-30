using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Events.Book;

public class BookCreatedDomainEvent : DomainEvent
{
    public BookId BookId { get; }
    public BookCreatedDomainEvent(BookId bookId) => BookId = bookId;
}
