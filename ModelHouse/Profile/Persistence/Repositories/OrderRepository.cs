using Microsoft.EntityFrameworkCore;
using ModelHouse.Profile.Domain.Models;
using ModelHouse.Profile.Domain.Repositories;
using ModelHouse.Shared.Persistence.Contexts;
using ModelHouse.Shared.Persistence.Repositories;

namespace ModelHouse.Profile.Persistence.Repositories;

public class OrderRepository: BaseRepository, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
        
    }
    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _context.Orders
            .Include(p => p.User)
            .Include(p => p.Project)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> ListByUserId(long id)
    {
        return await _context.Orders.
            Where(p=>p.UserId == id)
            .Include(p => p.User)
            .Include(p => p.Project)
            .ToListAsync();
    }

    public async Task<Order> FindByIdAsync(long id)
    {
        return await _context.Orders
            .Include(p => p.User)
            .Include(p => p.Project)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public void DeleteAsync(Order order)
    {
        _context.Orders.Remove(order);
    }

    public void UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
    }
}