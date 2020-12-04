using System.Threading.Tasks;
using PMA.Sop.Domain.Interfaces;
using PMA.Sop.Domain.User.Commands;
using PMA.Sop.Domain.User.Entities;

namespace PMA.Sop.Domain.User.Repositories
{
    public interface IApplicationUserInfoCommandRepository : IAsyncRepository<ApplicationUserInfo>
    {
        void Add(ApplicationUserInfo command);
        void UpdateRep(ApplicationUserInfo entity, UpdateApplicationUserInfoCommand model);
    }
}