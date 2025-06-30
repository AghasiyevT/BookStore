using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Events.Author;

public class AuthorBookAddedDomainEvent : DomainEvent
{
    public AuthorId AuthorId { get; }
    public BookId BookId { get; }

    public AuthorBookAddedDomainEvent(AuthorId authorId, BookId bookId)
    {
        AuthorId = authorId;
        BookId = bookId;
    }
}