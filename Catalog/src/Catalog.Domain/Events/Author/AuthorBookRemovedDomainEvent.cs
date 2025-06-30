using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Events.Author;

public class AuthorBookRemovedDomainEvent : DomainEvent
{
    public AuthorId AuthorId { get; }
    public BookId BookId { get; }

    public AuthorBookRemovedDomainEvent(AuthorId authorId, BookId bookId)
    {
        AuthorId = authorId;
        BookId = bookId;
    }
}
