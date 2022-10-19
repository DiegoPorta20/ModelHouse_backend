using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Services;
using ModelHouse.Interest.Resources;
using ModelHouse.Shared.Extensions;

namespace ModelHouse.Interest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RoomsController: ControllerBase
{
    private readonly IRoomService _roomService;
    private readonly IMapper _mapper;


    public RoomsController(IRoomService roomService, IMapper mapper)
    {
        _roomService = roomService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<RoomResource>> GetAllASync()
    {
        var rooms = await _roomService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(rooms);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRoomResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var room = _mapper.Map<SaveRoomResource, Room>(resource);

        var result = await _roomService.SaveAsync(room);

        if (!result.Success)
            return BadRequest(result.Message);

        var roomResource = _mapper.Map<Room, RoomResource>(result.Resource);

        return Ok(roomResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateRoomResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var room = _mapper.Map<UpdateRoomResource, Room>(resource);

        var result = await _roomService.UpdateAsync(id, room);

        if (!result.Success)
            return BadRequest(result.Message);

        var roomResource = _mapper.Map<Room, RoomResource>(result.Resource);

        return Ok(roomResource);
    }
    
}