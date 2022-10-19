using ModelHouse.Profile.Domain.Models;

namespace ModelHouse.Profile.Domain.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> ListAsync();
    Task<IEnumerable<Project>> ListByUserId(long id);
    Task<Project> FindByIdAsync(long id);
    Task<Project> FindByNameAsync(string title);
    Task AddAsync(Project project);
    void DeleteAsync(Project project);
    void UpdateAsync(Project project);
}