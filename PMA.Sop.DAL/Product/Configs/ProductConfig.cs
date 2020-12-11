using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PMA.Sop.DAL.Product.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Domain.Product.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Product.Entities.Product> builder)
        {
            builder.Property(x => x.Title).HasColumnType("nvarchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(1500)").HasMaxLength(1500).IsRequired();
            builder.Property(c => c.Price).IsRequired().HasColumnType("decimal(18,2)").HasPrecision(18, 2);
            builder.Property(c => c.PriceDiscount).IsRequired().HasColumnType("decimal(18,2)").HasPrecision(18, 2);

            builder.Property(x => x.EnglishTitle).HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(x => x.Code).HasColumnType("nchar(10)").HasMaxLength(10);
        }
    }
}