using ModelHouse.Interest.Domain.Models;

namespace ModelHouse.Interest.Domain.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> ListAsync();

    Task AddAsync(Service service);

    void Update(Service service);
    
    Task<Service> FindByIdAsync(int id);

}