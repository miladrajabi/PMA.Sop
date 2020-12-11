using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.DAL.Context;
using PMA.Sop.DAL.Data;
using PMA.Sop.Domain.Product.Entities;
using PMA.Sop.Domain.Product.Repositories.Brands;

namespace PMA.Sop.DAL.Product.Repositories.Brands
{
    public class BrandsCommandRepository : EfRepository<Brand>, IBrandsCommandRepository
    {
        public BrandsCommandRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsUniqueBrandAsync(string brand)
        {
            return await DbContext.Brands.AllAsync(x => x.Title.ToLower() != brand.ToLower());
        }
    }
}