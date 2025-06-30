using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities;

public class AuthorBook : Entity
{
    public AuthorId AuthorId { get; private set; }
    public BookId BookId { get; private set; }

    private AuthorBook() { }

    public AuthorBook(AuthorId authorId, BookId bookId)
    {
        AuthorId = authorId;
        BookId = bookId;
    }
}
