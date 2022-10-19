using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Services.Communication;

namespace ModelHouse.Interest.Domain.Services;

public interface IRoomService
{
    Task<IEnumerable<Room>> ListAsync();

    Task<RoomResponse> SaveAsync(Room room);

    Task<RoomResponse> UpdateAsync(int id, Room room);
}