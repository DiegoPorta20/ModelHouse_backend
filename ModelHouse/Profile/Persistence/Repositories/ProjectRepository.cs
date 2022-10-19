using Microsoft.EntityFrameworkCore;
using ModelHouse.Profile.Domain.Models;
using ModelHouse.Profile.Domain.Repositories;
using ModelHouse.Shared.Persistence.Contexts;
using ModelHouse.Shared.Persistence.Repositories;

namespace ModelHouse.Profile.Persistence.Repositories;

public class ProjectRepository: BaseRepository, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Project>> ListAsync()
    {
        return await _context.Projects
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Project>> ListByUserId(long id)
    {
        return await _context.Projects.
            Where(p=>p.UserId == id)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<Project> FindByIdAsync(long id)
    {
        return await _context.Projects
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Project> FindByNameAsync(string title)
    {
        return await _context.Projects
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task AddAsync(Project project)
    {
        await _context.Projects.AddAsync(project);
    }

    public void DeleteAsync(Project project)
    {
        _context.Projects.Remove(project);
    }

    public void UpdateAsync(Project project)
    {
        _context.Projects.Update(project);
    }
}