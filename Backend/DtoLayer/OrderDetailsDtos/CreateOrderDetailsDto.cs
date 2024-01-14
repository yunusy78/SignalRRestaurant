namespace DtoLayer.OrderDetailsDtos;

public class CreateOrderDetailsDto
{
    
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }
    
}