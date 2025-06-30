using Catalog.Domain.Events.Book;
using Catalog.Domain.Primitives;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities;


public class Book : Entity, IAggregateRoot
{
    public BookId Id { get; private set; }
    public string Title { get; private set; }
    public AuthorId AuthorId { get; private set; }
    public ISBN ISBN { get; private set; }
    public decimal Price { get; private set; }
    public BookCategory Category { get; private set; }
    public int StockQuantity { get; private set; }

    private readonly List<AuthorBook> _authorBooks = new();
    public IReadOnlyCollection<AuthorBook> AuthorBooks => _authorBooks.AsReadOnly();

    private Book() { }

    public Book(BookId id, string title, AuthorId authorId, ISBN isbn, decimal price, BookCategory category, int stockQuantity)
    {
        Id = id;
        Title = title;
        AuthorId = authorId;
        ISBN = isbn;
        Price = price;
        Category = category;
        StockQuantity = stockQuantity;
        AddDomainEvent(new BookCreatedDomainEvent(Id));
    }

    public void UpdateStock(int quantityChange)
    {
        StockQuantity += quantityChange;
        AddDomainEvent(new BookStockUpdatedDomainEvent(Id, StockQuantity));
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0)
            throw new ArgumentException("Price cannot be negative.");
        Price = newPrice;
        AddDomainEvent(new BookPriceChangedDomainEvent(Id, newPrice));
    }
}

