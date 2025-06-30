using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Events.Author;

public class AuthorCreatedDomainEvent : DomainEvent
{
    public AuthorId AuthorId { get; }
    public AuthorCreatedDomainEvent(AuthorId authorId) => AuthorId = authorId;
}
