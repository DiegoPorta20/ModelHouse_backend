using ModelHouse.Security.Domain.Models;

namespace ModelHouse.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(User user);
    int? ValidateToken(string token);
}