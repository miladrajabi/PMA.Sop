using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Sop.Domain.Product.Entities;

namespace PMA.Sop.DAL.Product.Configs
{
    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(x => x.Src).HasColumnType("varchar(1000)").HasMaxLength(1000).IsRequired();

            builder.Property(c => c.IsShow).HasDefaultValue(true);
            builder.Property(c => c.IsBaseImage).HasDefaultValue(false);

        }
    }
}