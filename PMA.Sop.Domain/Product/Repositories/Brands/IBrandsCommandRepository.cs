using System.Threading.Tasks;
using PMA.Sop.Domain.Interfaces;
using PMA.Sop.Domain.Product.Entities;
using PMA.Sop.Domain.User.Entities;

namespace PMA.Sop.Domain.Product.Repositories.Brands
{
    public interface IBrandsCommandRepository : IAsyncRepository<Brand>
    {
        Task<bool> IsUniqueBrandAsync(string brand);
    }
}