
using ModelHouse.Security.Domain.Models;

namespace ModelHouse.Profile.Domain.Models;

public class Project
{
    public long Id { get; set; }
    public string Title { get; set; }
    public float Price { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }
    public string Description { get; set; }
    public string Photo { get; set; }
    
    //Relation of the User
    public User User { get; set; }
    public long UserId { get; set; }
}