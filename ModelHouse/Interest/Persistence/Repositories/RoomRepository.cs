using Microsoft.EntityFrameworkCore;
using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Repositories;
using ModelHouse.Shared.Persistence.Contexts;
using ModelHouse.Shared.Persistence.Repositories;

namespace LearningCenter.API.Interest.Persistence.Repositories;

public class RoomRepository: BaseRepository, IRoomRepository
{
    public RoomRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Room>> ListAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task AddAsync(Room room)
    { 
        await _context.Rooms.AddAsync(room);
    }

    public void Update(Room room)
    {
        _context.Rooms.Update(room);
    }

    public async Task<Room> FindByIdAsync(int id)
    {
        return await _context.Rooms.FindAsync(id);
    }
}