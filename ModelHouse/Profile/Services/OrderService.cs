using ModelHouse.Profile.Domain.Models;
using ModelHouse.Profile.Domain.Repositories;
using ModelHouse.Profile.Domain.Services;
using ModelHouse.Security.Domain.Repositories;
using ModelHouse.Shared.Domain.Repositories;

namespace ModelHouse.Profile.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _orderRepository.ListAsync();
    }

    public async Task<IEnumerable<Order>> ListByUserId(long id)
    {
        return await _orderRepository.ListByUserId(id);
    }

    public async Task<OrderResponse> CreateAsync(Order order)
    {
        System.Console.WriteLine("nada");
        var user = await _userRepository.FindByIdAsync(order.UserId);
        System.Console.WriteLine("nada");
        if (user == null)
            return new OrderResponse("User is not exist");
        System.Console.WriteLine("Hola-0");
        var project_exist = await _projectRepository.FindByIdAsync(order.ProjectId);
        if (project_exist == null)
            return new OrderResponse("Project is not exist");
        System.Console.WriteLine("Hola-1");
        var order_exist = await _orderRepository.FindByIdAsync(order.Id);
        if (order_exist != null)
            return new OrderResponse("The User already has this project");
        System.Console.WriteLine("Hola");
        try
        {
            System.Console.WriteLine("Hola2");
            await _orderRepository.AddAsync(order);
            await _unitOfWork.CompleteAsync();
            return new OrderResponse(order);
        }
        catch (Exception e)
        {
            return new OrderResponse($"Failed to register a Project: {e.Message}");
        }
    }

    public async Task<OrderResponse> DeleteAsync(long id)
    {
        var order_exist = await _orderRepository.FindByIdAsync(id);
        if (order_exist == null)
            return new OrderResponse("the Project is not existing");
        try
        {
            _orderRepository.DeleteAsync(order_exist);
            await _unitOfWork.CompleteAsync();
            return new OrderResponse(order_exist);
        }
        catch (Exception e)
        {
            return new OrderResponse($"An error occurred while deleting the Order: {e.Message}");
        }
    }

    public Task<OrderResponse> UpdateAsync(long id, Order order)
    {
        throw new NotImplementedException();
    }

    public async Task<OrderResponse> GetOrderById(long id)
    {
        try
        {
            var account = await _orderRepository.FindByIdAsync(id);
            return new OrderResponse(account);
        }
        catch (Exception e)
        {
            return new OrderResponse($"Failed to find a current user Order: {e.Message}");
        }
    }
}