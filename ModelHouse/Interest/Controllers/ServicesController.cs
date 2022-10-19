using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Services;
using ModelHouse.Interest.Resources;
using ModelHouse.Shared.Extensions;

namespace ModelHouse.Interest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ServicesController: ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public ServicesController(IServiceService serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ServiceResource>> GetAllASync()
    {
        var service = await _serviceService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(service);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveServiceResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var service = _mapper.Map<SaveServiceResource, Service>(resource);

        var result = await _serviceService.SaveAsync(service);

        if (!result.Success)
            return BadRequest(result.Message);

        var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

        return Ok(serviceResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateServiceResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var service = _mapper.Map<UpdateServiceResource, Service>(resource);

        var result = await _serviceService.UpdateAsync(id, service);

        if (!result.Success)
            return BadRequest(result.Message);

        var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

        return Ok(serviceResource);
    }
    
}