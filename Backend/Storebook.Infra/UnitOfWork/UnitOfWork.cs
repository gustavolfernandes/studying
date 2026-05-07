using Storebook.Domain.Interfaces.UnitOfWork;

namespace Storebook.Infra.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly StorebookContext _context;

    public UnitOfWork(StorebookContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

