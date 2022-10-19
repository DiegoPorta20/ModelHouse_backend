using ModelHouse.Profile.Domain.Models;
using ModelHouse.Profile.Resources;

namespace ModelHouse.Profile.Mapping;

public class ModelToResourceProfile: AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Project, ProjectResource>();
        CreateMap<Order, OrderResource>();
    }
}