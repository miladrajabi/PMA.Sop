using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMA.Sop.Domain.Product.Entities;

namespace PMA.Sop.DAL.Product.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x=>x.Title).HasColumnType("nvarchar(200)").HasMaxLength(200).IsRequired();
        }
    }
}
