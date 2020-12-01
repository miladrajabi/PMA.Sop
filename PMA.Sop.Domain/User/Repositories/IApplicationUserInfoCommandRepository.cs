using System.Threading.Tasks;
using PMA.Sop.Domain.User.Entities;

namespace PMA.Sop.Domain.User.Repositories
{
    public interface IApplicationUserInfoCommandRepository 
    {
        void Add(ApplicationUserInfo command);
        Task AddAsync(ApplicationUserInfo command);

    }
}