
using ModelHouse.Security.Domain.Models;

namespace ModelHouse.Profile.Domain.Models;

public class Order
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public User User { get; set; }
    public long UserId { get; set; }
    public Project Project { get; set; }
    public long ProjectId { get; set; }
}