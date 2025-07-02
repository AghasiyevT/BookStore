using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.UnitTests.TestHelpers;

public static class AuthorHelper
{
    public static Author CreateTestAuthor()
    => new Author(AuthorId.CreateNew(), new FullName("Test", "Author"), new Email("test@domain.com"), new Bio("Sci-fi Writer"));
}
