using ModelHouse.Profile.Domain.Models;
using ModelHouse.Profile.Domain.Repositories;
using ModelHouse.Profile.Domain.Services;
using ModelHouse.Security.Domain.Repositories;
using ModelHouse.Shared.Domain.Repositories;

namespace ModelHouse.Profile.Services;

public class ProjectService: IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProjectService(IProjectRepository projectRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Project>> ListAsync()
    {
        return await _projectRepository.ListAsync();
    }

    public async Task<IEnumerable<Project>> ListByUserId(long id)
    {
        return await _projectRepository.ListByUserId(id);
    }

    public async Task<ProjectResponse> CreateAsync(Project project)
    {
        var User = await _userRepository.FindByIdAsync(project.UserId);
        if (User == null)
            return new ProjectResponse("User is not exist");
        var project_exist = await _projectRepository.FindByNameAsync(project.Title);
        if (project_exist != null)
            return new ProjectResponse("the user already has this project");
        try
        {
            await _projectRepository.AddAsync(project);
            await _unitOfWork.CompleteAsync();
            return new ProjectResponse(project);
        }
        catch (Exception e)
        {
            return new ProjectResponse($"Failed to register a Project: {e.Message}");
        }
    }

    public async Task<ProjectResponse> DeleteAsync(long project)
    {
        var project_exist = await _projectRepository.FindByIdAsync(project);
        if (project_exist == null)
            return new ProjectResponse("the Project is not existing");
        try
        {
            _projectRepository.DeleteAsync(project_exist);
            await _unitOfWork.CompleteAsync();
            return new ProjectResponse(project_exist);
        }
        catch (Exception e)
        {
            return new ProjectResponse($"An error occurred while deleting the Project: {e.Message}");
        }
    }

    public Task<ProjectResponse> UpdateAsync(long id, Project project)
    {
        throw new NotImplementedException();
    }

    public async Task<ProjectResponse> GetProjectById(long id)
    {
        try
        {
            var account = await _projectRepository.FindByIdAsync(id);
            return new ProjectResponse(account);
        }
        catch (Exception e)
        {
            return new ProjectResponse($"Failed to find a current user Project: {e.Message}");
        }
    }
}