namespace DtoLayer.CategoryDtos;

public class UpdateCategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}