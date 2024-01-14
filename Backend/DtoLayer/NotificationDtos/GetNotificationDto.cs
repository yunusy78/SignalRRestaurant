namespace DtoLayer.NotificationDtos;

public class GetNotificationDto
{
    public int NotificationId { get; set; }
    public string Title { get; set; }
    public string Icon { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
}