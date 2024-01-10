namespace DtoLayer.DiningTableDtos;

public class CreateDiningTableDto
{
    public string? TableName { get; set; }
    public int Capacity { get; set; }
    public bool Status { get; set; }
}