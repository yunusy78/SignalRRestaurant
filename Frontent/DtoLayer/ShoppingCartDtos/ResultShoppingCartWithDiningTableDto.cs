namespace DtoLayer.ShoppingCartDtos;

public class ResultShoppingCartWithDiningTableDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
    public int DiningTableId { get; set; }
    public string DiningTableName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string ImageUrl { get; set; }
}