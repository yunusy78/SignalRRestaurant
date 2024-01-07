using System.ComponentModel.DataAnnotations.Schema;
using EntityLayer.Concrete;

namespace EntityLayer.Concrete;

public class ShoppingCart
{
    
    public int Id { get; set; }
    
    
    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    [NotMapped]
    
    public double TotalPrice { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    
}