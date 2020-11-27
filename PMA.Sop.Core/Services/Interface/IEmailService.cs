using System.Threading.Tasks;

namespace PMA.Sop.Core.Services.Interface
{
    public interface IEmailService
    {
        Task Execute(string userEmail, string body, string subject);
    }
}