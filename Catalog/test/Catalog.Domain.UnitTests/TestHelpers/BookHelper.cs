using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.UnitTests.TestHelpers;

public static class BookHelper
{
    public static Book CreateTestBook()
        => new Book(
            BookId.CreateNew(),
            "Test Book",
            AuthorId.CreateNew(),
            new ISBN("1234567890"),
            10m,
            BookCategory.Fiction,
            10
        );
}
