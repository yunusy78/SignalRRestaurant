using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace DtoLayer.NotificationDtos;

public class ResultNotificationDto
{
    public int NotificationId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Icon { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }

    public List<SelectListItem> NotificationSymbol { get; set; }
    public List<SelectListItem> NotificationTypes { get; set; }
    
    public ResultNotificationDto()
    {
        NotificationSymbol = new List<SelectListItem>
        {
            new SelectListItem { Value = "la la-upload", Text = "Upload" },
            new SelectListItem { Value = "la la-twitter", Text = "Twitter" },
            new SelectListItem { Value = "la la-envelope", Text = "Email" },
            new SelectListItem { Value = "la la-calendar", Text = "Calendar" },
            new SelectListItem { Value = "la la-cogs", Text = "Settings" },
            new SelectListItem { Value = "la la-link", Text = "Link Variant" },
            new SelectListItem { Value = "la la-power-off", Text = "Power" },
            new SelectListItem { Value = "la la-align-justify", Text = "Format Line Spacing" },
            new SelectListItem { Value = "la la-bars", Text = "Menu" },
            new SelectListItem { Value = "la la-heart", Text = "Heart" },
            new SelectListItem { Value = "la la-comment", Text = "Comment" },
        };
        
        
        
        NotificationTypes = new List<SelectListItem>
        {
            new SelectListItem { Value = "notif-icon notif-primary", Text = "Primary" },
            new SelectListItem { Value = "notif-icon notif-info", Text = "Info" },
            new SelectListItem { Value = "notif-icon notif-warning", Text = "Warning" },
            new SelectListItem { Value = "notif-icon notif-danger", Text = "Danger" },
            new SelectListItem { Value = "notif-icon notif-success", Text = "Success" },
            new SelectListItem { Value = "notif-icon notif-secondary", Text = "Secondary" },
            new SelectListItem { Value = "notif-icon notif-dark", Text = "Dark" },
            new SelectListItem { Value = "notif-icon notif-light", Text = "Light" },
            new SelectListItem { Value = "notif-icon notif-muted", Text = "Muted" },
            new SelectListItem { Value = "notif-icon notif-link", Text = "Link" },
        };

    }
    
}