using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class SignalRContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SignalRDB;Trusted_Connection=True;MultipleActiveResultSets=true");
    }
    
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SocialMedia> SocialMediae { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderDetails> OrderDetails { get; set; }
    
    public DbSet<CashTransaction> CashTransactions { get; set; }
    
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    public DbSet<DiningTable> DiningTables { get; set; }
    
    
    public DbSet<Message> Messages { get; set; }
    
    public DbSet<Notification> Notifications { get; set; }
    
    public DbSet<AppUser> AppUsers { get; set; }
    
    public DbSet<AppRole> AppRoles { get; set; }
    
    
    public DbSet<ForgotPassword> ForgotPasswords { get; set; }
    
    public DbSet<AppUserRole> AppUserRoles { get; set; }
    
    
    
    
    
}