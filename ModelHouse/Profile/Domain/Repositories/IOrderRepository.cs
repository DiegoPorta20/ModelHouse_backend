using ModelHouse.Profile.Domain.Models;

namespace ModelHouse.Profile.Domain.Repositories;

public interface IOrderRepository
{ 
        Task<IEnumerable<Order>> ListAsync();
        Task<IEnumerable<Order>> ListByUserId(long id);
        Task<Order> FindByIdAsync(long id);
        Task AddAsync(Order order);
        void DeleteAsync(Order order);
        void UpdateAsync(Order order);
}