namespace Storebook.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}

