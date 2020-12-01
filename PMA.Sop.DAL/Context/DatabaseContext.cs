using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Domain.Zone.Entities;
using PMA.Sop.Domain.Wallet.Entities;


namespace PMA.Sop.DAL.Context
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUserAddress> ApplicationUserAddresses { get; set; }
        public DbSet<ApplicationUserInfo> ApplicationUserInfos { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Domain.Wallet.Entities.Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRoles");

            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });
            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserTokens");

            });
        }
    }
}