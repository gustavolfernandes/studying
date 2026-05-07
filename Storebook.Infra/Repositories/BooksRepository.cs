using Microsoft.EntityFrameworkCore;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;

namespace Storebook.Infra;

public class BooksRepository(StorebookContext context) : IBooksRepository
{
    public void Add(Book book) => context.Books.Add(book);
    public Task<Book?> GetByIdAsync(BookId bookId) => context.Books.FirstOrDefaultAsync(l => l.Id == bookId && l.Active);
    public Task<Book[]> GetAllPaginatedAsync(int skip, int take) => context.Books.Where(l => l.Active)
                                                                                   .Skip(skip)
                                                                                   .Take(take)
                                                                                   .OrderBy(l => l.Title)
                                                                                   .ToArrayAsync();
    public Task<int> CountAllBooks() => context.Books.CountAsync(l => l.Active);
}