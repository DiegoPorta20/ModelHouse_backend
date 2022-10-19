using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Resources;

namespace ModelHouse.Interest.Mapping;

public class ModelToResourceProfile: AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Area, AreaResource>();
        CreateMap<Room, RoomResource>();
        CreateMap<Service, ServiceResource>();
    }
}