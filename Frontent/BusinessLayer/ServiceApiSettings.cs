namespace BusinessLayer;

public class ServiceApiSettings
{
    public string IdentityServerAPI { get; set; }
    public string BaseUri { get; set; }
    
    public ServiceApi About { get; set; }
    public ServiceApi Testimonial { get; set; }
    
    
    public ServiceApi Product { get; set; }
    
    public ServiceApi Category { get; set; }
    
    
    public ServiceApi Contact { get; set; }
    
    public ServiceApi Feature { get; set; }
    
    public ServiceApi SocialMedia { get; set; }
    
    public ServiceApi Reservation { get; set; }
    
    public ServiceApi Discount { get; set; }
    
    public ServiceApi ShoppingCart { get; set; }
    
    public ServiceApi DiningTable { get; set; }
    
    
    
}


public class ServiceApi
{
    public string Path { get; set; }
    
    
}