using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class AppUser
{
    [Key]
    public int UserId { get; set; }
    public string UserEmail { get; set; }
    public string PasswordHash { get; set; }
}