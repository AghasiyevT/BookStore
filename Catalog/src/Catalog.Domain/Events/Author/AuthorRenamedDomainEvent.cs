using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Events.Author;

public class AuthorRenamedDomainEvent : DomainEvent
{
    public AuthorId AuthorId { get; }
    public FullName NewName { get; }

    public AuthorRenamedDomainEvent(AuthorId authorId, FullName newName)
    {
        AuthorId = authorId;
        NewName = newName;
    }
}
