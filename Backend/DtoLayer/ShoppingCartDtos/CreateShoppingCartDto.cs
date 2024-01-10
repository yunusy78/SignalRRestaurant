namespace DtoLayer.ShoppingCartDtos;

public class CreateShoppingCartDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public int DiningTableId { get; set; }
    public DateTime CreatedDate { get; set; }
}