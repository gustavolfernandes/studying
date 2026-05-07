using Storebook.Domain.Entities;
using System;

namespace Storebook.Domain.Interfaces.Repositories;

public interface IBooksRepository
{
    void Add(Book book);
    Task<Book?> GetByIdAsync(BookId bookId);
    Task<Book[]> GetAllPaginatedAsync(int skip, int take);
    Task<int> CountAllBooks();
}