using ModelHouse.Security.Resources;

namespace ModelHouse.Profile.Resources;

public class OrderResource
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public UserResource User { get; set; }
    public long UserId { get; set; }
    
    public ProjectResource Project { get; set; }
    public long ProjectId { get; set; }
}