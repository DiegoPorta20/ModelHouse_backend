using ModelHouse.Interest.Domain.Models;
using ModelHouse.Interest.Domain.Repositories;
using ModelHouse.Interest.Domain.Services;
using ModelHouse.Shared.Domain.Repositories;

namespace ModelHouse.Interest.Services;

public class AreaService: IAreaService
{
    private readonly IAreaRepository _areaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AreaService(IAreaRepository areaRepository, IUnitOfWork unitOfWork)
    {
        _areaRepository = areaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Area>> ListAsync()
    {
        return await _areaRepository.ListAsync();
    }

    public async Task<AreaResponse> SaveAsync(Area area)
    {
        try
        {
            await _areaRepository.AddAsync(area);
            await _unitOfWork.CompleteAsync();

            return new AreaResponse(area);
        }
        catch (Exception e)
        {
            return new AreaResponse($"An error occurred while saving the area: {e.Message}");
        }
    }

    public async Task<AreaResponse> UpdateAsync(int id, Area area)
    {
        var existingArea = await _areaRepository.FindByIdAsync(id);
        if (existingArea == null)
            return new AreaResponse("Area not found");
        existingArea.Check = area.Check;
        try
        {
            _areaRepository.Update(existingArea);
            await _unitOfWork.CompleteAsync();

            return new AreaResponse(existingArea);
        }
        catch (Exception e)
        {
            return new AreaResponse($"An error occurred while saving the area: {e.Message}");
        }
    }
}