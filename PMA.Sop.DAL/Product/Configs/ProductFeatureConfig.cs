using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Sop.Domain.Product.Entities;

namespace PMA.Sop.DAL.Product.Configs
{
    public class ProductFeatureConfig : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.Property(x => x.Title).HasColumnType("nvarchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(3500)").HasMaxLength(1500).IsRequired();
        }
    }
}
