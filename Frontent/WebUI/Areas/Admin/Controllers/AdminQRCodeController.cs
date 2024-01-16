using Microsoft.AspNetCore.Mvc;
using QRCoder;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminQRCodeController : Controller
{
    // GET
    public IActionResult Index()
    {
        QRCodeModelView model = new();
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(QRCodeModelView model)
    {
        
        
        PayloadGenerator.Payload? payload = null;
        switch (model.QRCodeType)
        {
            case 1: // compose sms
                payload = new PayloadGenerator.SMS(model.SMSPhoneNumber, model.SMSBody);
                break;
            case 2: // compose whatsapp message
                payload = new PayloadGenerator.WhatsAppMessage(model.WhatsAppNumber, model.WhatsAppMessage);
                break;
            case 3: //compose email
                payload = new PayloadGenerator.Mail(model.ReceiverEmailAddress, model.EmailSubject, model.EmailMessage);
                break;
            case 4: // wifi qr code
                payload = new PayloadGenerator.WiFi(model.WIFIName, model.WIFIPassword, PayloadGenerator.WiFi.Authentication.WPA);
                break;
            case 5: // url qr code
                payload = new PayloadGenerator.Url(model.TableName);
                break;
        }

        QRCodeGenerator qrGenerator = new();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload);
        BitmapByteQRCode qrCode = new(qrCodeData);
        string base64String = Convert.ToBase64String(qrCode.GetGraphic(20));
        model.QRImageURL = "data:image/png;base64," + base64String;
        return View("Index", model);
    }
    
    
}