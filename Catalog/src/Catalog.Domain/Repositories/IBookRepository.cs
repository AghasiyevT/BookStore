using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Repositories;

public interface IBookRepository
{
    Task<Book?> GetByIdAsync(BookId id);
    void Add(Book book);
    void Remove(Book book);
}
