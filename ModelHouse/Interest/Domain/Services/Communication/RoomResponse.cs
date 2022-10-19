using ModelHouse.Interest.Domain.Models;
using ModelHouse.Shared.Domain.Services.Communication;

namespace ModelHouse.Interest.Domain.Services.Communication;

public class RoomResponse: BaseResponse<Room>
{
    public RoomResponse(Room resource) : base(resource)
    {
    }

    public RoomResponse(string message) : base(message)
    {
    }
}