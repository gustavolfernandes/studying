using Storebook.Domain.Entities;
using System;

namespace Storebook.Domain.Interfaces.Repositories;

public interface ILivrosRepository
{
    void Add(Livro livro);
    Task<Livro?> GetByIdAsync(LivroId livroId);
    Task<Livro[]> GetAllPaginatedAsync(int skip, int take);
    Task<int> CountAllLivros();
}