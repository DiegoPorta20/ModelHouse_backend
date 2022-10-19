using ModelHouse.Profile.Domain.Models;
using ModelHouse.Profile.Resources;

namespace ModelHouse.Profile.Mapping;

public class ResourceToModelProfile:AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProjectResource, Project>();
        CreateMap<SaveOrderResource, Order>();
    }
}