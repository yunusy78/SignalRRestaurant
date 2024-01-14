namespace DtoLayer.OrderDtos;

public class GetOrderDto
{
    public int OrderId { get; set; }
    public string TableNumber { get; set; }
    public string Description { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }
}