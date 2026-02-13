using Microsoft.EntityFrameworkCore;
using Storebook.Domain.Entities;
using Storebook.Domain.Interfaces.Repositories;

namespace Storebook.Infra;

public class LivrosRepository(StorebookContext context) : ILivrosRepository
{
    public void Add(Livro livro) => context.Livros.Add(livro);
    public Task<Livro?> GetByIdAsync(LivroId livroId) => context.Livros.FirstOrDefaultAsync(l => l.Id == livroId && l.Ativo);
    public Task<Livro[]> GetAllPaginatedAsync(int skip, int take) => context.Livros.Where(l => l.Ativo)
                                                                                   .Skip(skip)
                                                                                   .Take(take)
                                                                                   .OrderBy(l => l.Titulo)
                                                                                   .ToArrayAsync();
    public Task<int> CountAllLivros() => context.Livros.CountAsync(l => l.Ativo);
}