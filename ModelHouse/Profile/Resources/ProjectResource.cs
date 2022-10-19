using ModelHouse.Security.Resources;

namespace ModelHouse.Profile.Resources;

public class ProjectResource
{
    public long Id { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    
    public UserResource User { get; set; }
    public long UserId { get; set; }
}