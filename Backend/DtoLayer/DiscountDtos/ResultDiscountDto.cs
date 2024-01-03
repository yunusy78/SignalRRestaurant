namespace DtoLayer.DiscountDtos;

public class ResultDiscountDto
{
    public int DiscountId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}