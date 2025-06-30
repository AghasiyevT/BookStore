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


    private readonly List<AuthorBook> _authorBooks = new();
    public IReadOnlyCollection<AuthorBook> AuthorBooks => _authorBooks.AsReadOnly();

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

    public void LinkBook(BookId bookId)
    {
        if (_authorBooks.Any(ab => ab.BookId == bookId)) return;
        _authorBooks.Add(new AuthorBook(Id, bookId));
        AddDomainEvent(new AuthorBookAddedDomainEvent(Id, bookId));
    }

    public void UnlinkBook(BookId bookId)
    {
        var link = _authorBooks.FirstOrDefault(ab => ab.BookId == bookId);
        if (link != null)
        {
            _authorBooks.Remove(link);
            AddDomainEvent(new AuthorBookRemovedDomainEvent(Id, bookId));
        }
    }
}

