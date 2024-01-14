using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class AppUserRole
{
    [Key]
    public int AppUserRoleId { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public int AppRoleId { get; set; }
    public AppRole AppRole { get; set; }
    
}