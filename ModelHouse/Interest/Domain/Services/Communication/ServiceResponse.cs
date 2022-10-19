using ModelHouse.Interest.Domain.Models;
using ModelHouse.Shared.Domain.Services.Communication;

namespace ModelHouse.Interest.Domain.Services.Communication;

public class ServiceResponse: BaseResponse<Service>
{
    public ServiceResponse(Service resource) : base(resource)
    {
    }

    public ServiceResponse(string message) : base(message)
    {
    }
}