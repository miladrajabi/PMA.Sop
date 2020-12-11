using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.Domain.Product.Entities;
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

        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Domain.Wallet.Entities.Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }

        #region Product
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Domain.Product.Entities.Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductTechnical> ProductTechnicals { get; set; }

        #endregion

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

            #region Products

            builder.Entity<Brand>().ToTable(nameof(Brands), "pr");
            builder.Entity<Category>().ToTable(nameof(Categories), "pr");
            builder.Entity<Domain.Product.Entities.Product>().ToTable(nameof(Products), "pr");
            builder.Entity<ProductFeature>().ToTable(nameof(ProductFeatures), "pr");
            builder.Entity<ProductImage>().ToTable(nameof(ProductImages), "pr");
            builder.Entity<ProductTechnical>().ToTable(nameof(ProductTechnicals), "pr");

            #endregion
        }
    }
}