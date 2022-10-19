using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Services.Communication;

namespace ModelHouse.Interest.Domain.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();

    Task<ServiceResponse> SaveAsync(Service service);

    Task<ServiceResponse> UpdateAsync(int id, Service service);
}