using Catalog.Domain.Entities;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Repositories;


public interface IAuthorRepository
{
    Task<Author?> GetByIdAsync(AuthorId id);
    void Add(Author author);
    void Remove(Author author);
}
