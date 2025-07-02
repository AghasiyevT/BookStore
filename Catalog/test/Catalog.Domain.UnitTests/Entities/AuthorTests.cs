using Catalog.Domain.Entities;
using Catalog.Domain.Events.Author;
using Catalog.Domain.UnitTests.TestHelpers;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.UnitTests.Entities;

public class AuthorTests
{
    private readonly Author _author;
    private readonly BookId _bookId;

    public AuthorTests()
    {
        _author = AuthorHelper.CreateTestAuthor();
        _bookId = BookId.CreateNew();
    }

    [Fact(DisplayName = "AuthorCreatedDomainEvent should raise with valid data")]
    public void Constructor_WhenAuthorIsCreated_RaisesCreatedEvent()
    {
        // Arrange
        var authorId = AuthorId.CreateNew();
        var authorName = new FullName("John", "Doe");
        var email = new Email("johnDoe@gmail.com");
        var bio = new Bio("This is a bio of John Doe.");

        // Act
        var author = new Author(authorId, authorName, email, bio);

        // Assert
        var authorCreatedEvent = author.DomainEvents.OfType<AuthorCreatedDomainEvent>().FirstOrDefault();
        Assert.NotNull(authorCreatedEvent);
        Assert.Equal(authorId, authorCreatedEvent.AuthorId);
    }

    [Fact]
    public void LinkBook_WhenBookNotLinked_AddsAuthorBookAndRaisesBookAddedEvent()
    {
        // Act
        _author.LinkBook(_bookId);

        // Assert
        Assert.Contains(_author.AuthorBooks, ab => ab.BookId == _bookId && ab.AuthorId == _author.Id);
        Assert.Contains(_author.DomainEvents, e => e is AuthorBookAddedDomainEvent bookAddedEvent && bookAddedEvent.BookId == _bookId && bookAddedEvent.AuthorId == _author.Id);
    }

    [Fact]
    public void LinkBook_WhenBookAlreadyLinked_DoesNotDuplicateOrRaiseEvent()
    {
        // Arrange
        _author.LinkBook(_bookId);
        _author.ClearDomainEvents();

        // Act
        _author.LinkBook(_bookId);

        // Assert
        Assert.Single(_author.AuthorBooks.Where(ab => ab.BookId == _bookId).ToList());
        Assert.Null(_author.DomainEvents.OfType<AuthorBookAddedDomainEvent>().FirstOrDefault());
    }

    [Fact]
    public void UnlinkBook_WhenBookUnLinked_RemovesBookAndRaisesBookRemovedEvent()
    {
        // Arrange
        _author.LinkBook(_bookId);
        _author.ClearDomainEvents();

        // Act
        _author.UnlinkBook(_bookId);

        // Assert
        var books = _author.AuthorBooks.Where(ab => ab.BookId == _bookId).ToList();
        Assert.Empty(books);
        Assert.Contains(_author.DomainEvents, ab => ab is AuthorBookRemovedDomainEvent authorBookRemovedEvent && authorBookRemovedEvent.BookId == _bookId && authorBookRemovedEvent.AuthorId == _author.Id);
    }

    [Fact]
    public void UnlinkBook_WhenBookDoesNotLinkedYet_DoesNotUnlinksOrRaiseEvent()
    {
        // Arrange
        _author.ClearDomainEvents();

        // Act
        _author.UnlinkBook(_bookId);

        // Assert
        Assert.Null(_author.DomainEvents.OfType<AuthorBookRemovedDomainEvent>().FirstOrDefault());
    }

}
