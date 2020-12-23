using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.DAL.Context;
using PMA.Sop.DAL.Data;
using PMA.Sop.Domain.Product.Entities;
using PMA.Sop.Domain.Product.Repositories.Categories;

namespace PMA.Sop.DAL.Product.Repositories.Categories
{
    public class CategoryCommandRepository : EfRepository<Category>, ICategoryCommandRepository
    {
        public CategoryCommandRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IReadOnlyList<Category>> ListAllAsync(bool asNoTracking = false)
        {
            var rep =await _dbSet.Include(x => x.Parent).AsNoTracking().ToListAsync();
            return rep;
        }
    }
}