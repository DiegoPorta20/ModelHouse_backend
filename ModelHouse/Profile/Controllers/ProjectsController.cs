using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelHouse.Profile.Domain.Models;
using ModelHouse.Profile.Domain.Services;
using ModelHouse.Profile.Resources;
using ModelHouse.Shared.Extensions;

namespace ModelHouse.Profile.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProjectsController: ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;

    public ProjectsController(IProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProjectResource>> GetAllAsync()
    {
        var projects = await _projectService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
        return resources;
    }
    
    [HttpGet("" +
             "user/{id}")]
    public async Task<IEnumerable<ProjectResource>> GetAllByUserId(long id)
    {
        var projects = await _projectService.ListByUserId(id);
        var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
        return resources;
    }
    [HttpGet("{id}")]
    public async Task<ProjectResource> GetAccountById(long id)
    {
        var projectId = await _projectService.GetProjectById(id);
        var resources = _mapper.Map<Project, ProjectResource>(projectId.Resource);
        return resources;
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _projectService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var projectResource = _mapper.Map<Project, ProjectResource>(result.Resource);

        return Ok(projectResource);
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProjectResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var project = _mapper.Map<SaveProjectResource, Project>(resource);

        var result = await _projectService.CreateAsync(project);

        if (!result.Success)
            return BadRequest(result.Message);

        var clientResource = _mapper.Map<Project, ProjectResource>(result.Resource);
        return Ok(clientResource);
    }
}