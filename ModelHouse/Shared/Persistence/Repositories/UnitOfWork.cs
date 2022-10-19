using ModelHouse.Shared.Domain.Repositories;
using ModelHouse.Shared.Persistence.Contexts;

namespace LearningCenter.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }


    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}