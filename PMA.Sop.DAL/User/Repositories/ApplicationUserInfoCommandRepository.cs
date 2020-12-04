using System;
using PMA.Sop.DAL.Context;
using PMA.Sop.DAL.Data;
using PMA.Sop.Domain.User.Commands;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Domain.User.Repositories;

namespace PMA.Sop.DAL.User.Repositories
{
    public class ApplicationUserInfoCommandRepository : EfRepository<ApplicationUserInfo>, IApplicationUserInfoCommandRepository
    {

        public ApplicationUserInfoCommandRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public void Add(ApplicationUserInfo command)
        {
            DbContext.ApplicationUserInfos.Add(command);
        }

        public void UpdateRep(ApplicationUserInfo entity, UpdateApplicationUserInfoCommand model)
        {
            entity.Gender = model.Gender;
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Birthdate = model.Birthdate;
            entity.ModifiedId = model.ModifiedId;
            entity.ModifiedDate = DateTime.Now;

        }
    }
}