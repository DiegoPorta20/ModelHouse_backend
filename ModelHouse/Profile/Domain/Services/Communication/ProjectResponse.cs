using ModelHouse.Profile.Domain.Models;
using ModelHouse.Shared.Domain.Services.Communication;

namespace ModelHouse.Profile.Domain.Services;

public class ProjectResponse: BaseResponse<Project>
{
    public ProjectResponse(Project resource) : base(resource)
    {
        
    }

    public ProjectResponse(string message) : base(message)
    {
        
    }
}