using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Services.Communication;

namespace ModelHouse.Interest.Domain.Services;

public interface IAreaService
{
    Task<IEnumerable<Area>> ListAsync();

    Task<AreaResponse> SaveAsync(Area area);

    Task<AreaResponse> UpdateAsync(int id, Area area);
}