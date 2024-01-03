﻿using EntityLayer.Concrete;
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
    
    
    
    
}