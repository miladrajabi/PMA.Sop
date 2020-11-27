using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using PMA.Sop.Core.Services.Interface;

namespace PMA.Sop.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _mailAddress;
        private readonly string _mailPassword;
        public EmailService(string mailAddress, string mailPassword)
        {
            _mailAddress = mailAddress;
            _mailPassword = mailPassword;
        }


        public Task Execute(string userEmail, string body, string subject)
        {
            //enable less secure apps in account google with link
            //https://myaccount.google.com/lesssecureapps

            var client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Timeout = 1000000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mailAddress, _mailPassword)
            };
            //در خط بعدی ایمیل  خود و پسورد ایمیل خود  را جایگزین کنید
            var message = new MailMessage(_mailAddress, userEmail, subject, body)
            {
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess
            };
            client.Send(message);
            return Task.CompletedTask;
        }
    }
}
