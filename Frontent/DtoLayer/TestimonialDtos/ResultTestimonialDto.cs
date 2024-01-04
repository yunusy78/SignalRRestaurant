namespace DtoLayer.TestimonialDtos;

public class ResultTestimonialDto
{
    public int TestimonialId { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedAt { get; set; }
}