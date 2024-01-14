namespace EntityLayer.Concrete;

public class ForgotPassword
{
    public int Id { get; set; }
    public string? Email { get; set; }
    
    public string UserId { get; set; }
    
    public string? PasswordHash { get; set; }
    
    public string? ResetToken { get; set; }
    
    public DateTime? ResetTokenExpires { get; set; }
    
}