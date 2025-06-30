using Catalog.Domain.Events.Author;
using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities;

public class Author : Entity, IAggregateRoot
{
    public AuthorId Id { get; private set; }
    public FullName Name { get; private set; }
    public Email Email { get; private set; }
    public Bio Bio { get; private set; }
    private readonly List<BookId> _bookIds = new();
    public IReadOnlyCollection<BookId> BookIds => _bookIds.AsReadOnly();

    private Author() { }

    public Author(AuthorId id, FullName name, Email email, Bio bio)
    {
        Id = id;
        Name = name;
        Email = email;
        Bio = bio;
        AddDomainEvent(new AuthorCreatedDomainEvent(Id));
    }

    public void Rename(FullName newName)
    {
        Name = newName;
        AddDomainEvent(new AuthorRenamedDomainEvent(Id, newName));
    }

    public void AddBook(BookId bookId)
    {
        if (!_bookIds.Contains(bookId))
        {
            _bookIds.Add(bookId);
            AddDomainEvent(new AuthorBookAddedDomainEvent(Id, bookId));
        }
    }

    public void RemoveBook(BookId bookId)
    {
        if (_bookIds.Remove(bookId))
        {
            AddDomainEvent(new AuthorBookRemovedDomainEvent(Id, bookId));
        }
    }
}

