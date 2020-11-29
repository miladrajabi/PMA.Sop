using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.Domain.User.Entities;

namespace PMA.Sop.DAL.Context
{
    public class AccDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AccDbContext(DbContextOptions<AccDbContext> options) : base(options)
        {

        }
    }
}