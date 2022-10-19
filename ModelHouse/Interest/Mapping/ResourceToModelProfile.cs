using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Resources;

namespace ModelHouse.Interest.Mapping;

public class ResourceToModelProfile: AutoMapper.Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAreaResource, Area>();
        CreateMap<UpdateAreaResource, Area>();
        CreateMap<SaveRoomResource, Room>();
        CreateMap<UpdateRoomResource, Room>();
        CreateMap<SaveServiceResource, Service>();
        CreateMap<UpdateServiceResource, Service>();
    }
}