using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Repositories;
using ModelHouse.Interest.Domain.Services;
using ModelHouse.Interest.Domain.Services.Communication;
using ModelHouse.Shared.Domain.Repositories;

namespace LearningCenter.API.Interest.Services;

public class RoomService: IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoomService(IRoomRepository roomRepository, IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Room>> ListAsync()
    {
        return await _roomRepository.ListAsync();
    }

    public async Task<RoomResponse> SaveAsync(Room room)
    {
        try
        {
            await _roomRepository.AddAsync(room);
            await _unitOfWork.CompleteAsync();

            return new RoomResponse(room);
        }
        catch (Exception e)
        {
            return new RoomResponse($"An error occurred while saving the room: {e.Message}");
        }
    }

    public async Task<RoomResponse> UpdateAsync(int id, Room room)
    {
        var existingArea = await _roomRepository.FindByIdAsync(id);
        if (existingArea == null)
            return new RoomResponse("Room not found");
        existingArea.Check = room.Check;
        try
        {
            _roomRepository.Update(existingArea);
            await _unitOfWork.CompleteAsync();

            return new RoomResponse(existingArea);
        }
        catch (Exception e)
        {
            return new RoomResponse($"An error occurred while saving the room: {e.Message}");
        }
    }
}