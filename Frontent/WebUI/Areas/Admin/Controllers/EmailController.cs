using DtoLayer.EmailDtos;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class EmailController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    
    public IActionResult Index(CreateEmailDto createEmailDto)
    {
        MimeMessage message = new MimeMessage();
        MailboxAddress from = new MailboxAddress("BurgerClash", "globetrotter.org.no@gmail.com");
        message.From.Add(from);
        MailboxAddress to = new MailboxAddress("User", createEmailDto.ReceiverEmail);
        message.To.Add(to);
        
        // HTML içeriği için TextPart yerine HtmlPart kullanılır.
        message.Body = new TextPart("html")
        {
            Text = $@"<html>
                    <body>
                        <h2>{createEmailDto.Subject}</h2>
                        <p>{createEmailDto.Message}</p>
                    </body>
                </html>"
        };
        
        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("globetrotter.org.no@gmail.com", "zdwvxgqvtqheqmfi");
        client.Send(message);
        client.Disconnect(true);
        client.Dispose();
        return RedirectToAction("Index", "Default");
    }
}