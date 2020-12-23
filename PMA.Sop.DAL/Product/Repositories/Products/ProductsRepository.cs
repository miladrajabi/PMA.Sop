using System.Threading.Tasks;
using PMA.Sop.DAL.Context;
using PMA.Sop.DAL.Data;
using PMA.Sop.Domain.Product.Repositories.Products;

namespace PMA.Sop.DAL.Product.Repositories.Products
{
    public class ProductsRepository : EfRepository<Domain.Product.Entities.Product>, IProductsRepository
    {
        public ProductsRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        //public override Task AddAsync(Domain.Product.Entities.Product entity)
        //{
        //    DbContext.Products.Add(new Domain.Product.Entities.Product()
        //    {
        //    });
        //}
    }
}