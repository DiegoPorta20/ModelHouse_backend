using ModelHouse.Interest.Domain.Models;
using ModelHouse.Shared.Domain.Services.Communication;

public class AreaResponse: BaseResponse<Area>
{
    public AreaResponse(Area resource) : base(resource)
    {
    }

    public AreaResponse(string message) : base(message)
    {
    }
}