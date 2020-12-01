using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Sop.Domain.User.Entities;
using PMA.Sop.Domain.Zone.Entities;

namespace PMA.Sop.DAL.User.Configs
{
    public class ApplicationUserAddressConfig : IEntityTypeConfiguration<ApplicationUserAddress>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserAddress> builder)
        {
            builder.Property(c => c.PostCode).HasColumnType("nchar(10)").HasMaxLength(10);
            builder.Property(c => c.PostalAddress).HasColumnType("nvarchar(350)").HasMaxLength(350);
            builder.Property(c => c.DistrictId).IsRequired();
            builder.Property(c => c.RecipientIsSelf).HasDefaultValue(true);

            builder.Property(c => c.RecipientFirstName).IsRequired().HasMaxLength(150);
            builder.Property(c => c.RecipientLastName).IsRequired().HasMaxLength(250);
            builder.Property(c => c.RecipientNationalCode).HasColumnType("nchar(10)").HasMaxLength(10);
        }
    }
}