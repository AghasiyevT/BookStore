using Catalog.Domain.Entities;
using Catalog.Domain.Events.Book;
using Catalog.Domain.UnitTests.TestHelpers;

namespace Catalog.Domain.UnitTests.Entities;

public class BookTests
{
    private readonly Book _book;
    public BookTests()
    {
        _book = BookHelper.CreateTestBook();
    }

    [Fact(DisplayName = "BookCreatedDomainEvent should raise")]
    public void Constructor_WhenBookIsCreated_RaisesCreatedEvent()
    {
        //Assert
        var bookCreatedEvent = _book.DomainEvents.OfType<BookCreatedDomainEvent>().FirstOrDefault();
        Assert.Contains(_book.DomainEvents, e => e is BookCreatedDomainEvent);
    }

    [Fact(DisplayName = "Book Quantity has to be changed and BookStockUpdatedDomainEvent should raise")]
    public void UpdateStockQuantity_WhenQuantityAdded_UpdatesStockAndRaisesEvent()
    {
        // Arrange
        var newQuantity = 5;
        _book.ClearDomainEvents();

        // Act
        _book.UpdateStock(newQuantity);

        // Assert
        var stockUpdatedEvent = _book.DomainEvents.OfType<BookStockUpdatedDomainEvent>().FirstOrDefault();
        Assert.Equal(15, _book.StockQuantity);
        Assert.NotNull(stockUpdatedEvent);
        Assert.Contains(_book.DomainEvents, e => e is BookStockUpdatedDomainEvent);
    }

    [Fact(DisplayName = "Book Price has to be cahnged and BookPriceChangedDomainEvent should raise")]
    public void ChangePrice_WhenPriceIsPositive_ChangesPriceAndRaisesEvent()
    {
        //Arrange
        var newPrice = 5m;
        _book.ClearDomainEvents();

        // Act
        _book.ChangePrice(newPrice);

        // Assert
        var priceChangedEvent = _book.DomainEvents.OfType<BookPriceChangedDomainEvent>().FirstOrDefault();
        Assert.Equal(newPrice, _book.Price);
        Assert.NotNull(priceChangedEvent);
        Assert.Contains(_book.DomainEvents, e => e is BookPriceChangedDomainEvent);
    }

    [Fact(DisplayName = "Has to throw ArgumentException because of negative price")]
    public void ChangePrice_WhenPriceIsNegative_ThrowsArgumentException()
    {
        // Arrange
        var newPrice = -5m;
        _book.ClearDomainEvents();
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _book.ChangePrice(newPrice));
    }
}
