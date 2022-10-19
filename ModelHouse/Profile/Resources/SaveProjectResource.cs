using System.ComponentModel.DataAnnotations;

namespace ModelHouse.Profile.Resources;

public class SaveProjectResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [Required]
    public float Price { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string Category { get; set; }
    
    [Required]
    [MaxLength(120)]
    public string Location { get; set; }
    
    [Required]
    [MaxLength(300)]
    public string Description { get; set; }
    
    [Required]
    public string Photo { get; set; }
    
    [Required]
    public long UserId { get; set; }
    
}