using System.Threading.Tasks;
using PMA.Sop.DAL.Context;
using PMA.Sop.Domain.SeedWork;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Domain.User.Repositories;

namespace PMA.Sop.DAL.User.Repositories
{
    public class ApplicationUserInfoCommandRepository : IApplicationUserInfoCommandRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ApplicationUserInfoCommandRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(ApplicationUserInfo command)
        {
            _databaseContext.ApplicationUserInfos.Add(command);
        }

        public async Task AddAsync(ApplicationUserInfo command)
        {
            await _databaseContext.ApplicationUserInfos.AddAsync(command);
        }
    }
}