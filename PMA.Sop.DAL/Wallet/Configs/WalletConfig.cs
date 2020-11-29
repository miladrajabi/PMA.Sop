using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PMA.Sop.DAL.Wallet.Configs
{
    public class WalletConfig : IEntityTypeConfiguration<Domain.Wallet.Entities.Wallet>
    {
        public void Configure(EntityTypeBuilder<Domain.Wallet.Entities.Wallet> builder)
        {
            builder.Property(c => c.Amount).IsRequired().HasColumnType("decimal(18,2)").HasPrecision(18, 2);

            builder.Property(c => c.Description).HasMaxLength(1000);

            //builder.HasOne(c => c.ApplicationUser).WithMany(x=>x.Wallets);
            //builder.HasOne(c => c.WalletType).WithMany(x=>x.Wallets);
        }
    }
}