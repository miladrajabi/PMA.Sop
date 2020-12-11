using Microsoft.EntityFrameworkCore;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Domain.Wallet.Entities;
using PMA.Sop.Domain.Zone.Entities;

namespace PMA.Sop.ApplicationServices.Interfaces
{
    public interface IDatabaseContext
    {
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<UserInfo> ApplicationUserInfos { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Domain.Wallet.Entities.Wallet> Wallets { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
    }
}