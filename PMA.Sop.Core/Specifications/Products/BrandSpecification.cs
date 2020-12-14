using System.Linq.Dynamic;
using Ardalis.Specification;
using PMA.Sop.Domain.Product.Entities;

namespace PMA.Sop.ApplicationServices.Specifications.Products
{
    public sealed class BrandSpecification : Specification<Brand>
    {
        public BrandSpecification()
        {

        }
        public BrandSpecification(int brandId)
        {
            Query.Where(x => x.Id == brandId);
        }
        public BrandSpecification(int skip, int pageSize, string searchKey, string sortColumn, string sortDirection = "asc")
        {
            ISpecificationBuilder<Brand> query = Query;

            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(m => m.Title.Contains(searchKey) || m.EnglishTitle.Contains(searchKey));

            }
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortDirection)))
            //    query = 
            query = query?.Skip(skip).Take(pageSize);
        }
        //public ISpecification<Brand> BrandList(int skip, int pageSize, string searchKey, string sortColumn, string sortDirection = "asc")
        //{
        //    ISpecification<Brand> q=new BrandSpecification();
        //    ISpecificationBuilder<Brand> query = null;
        //    if (!string.IsNullOrEmpty(searchKey))
        //    {
        //        query = Query.Where(m => m.Title.Contains(searchKey) || m.EnglishTitle.Contains(searchKey));

        //    }
        //    //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortDirection)))
        //    //    query = 
        //    query = query?.Skip(skip).Take(pageSize);
        //    return q;
        //}
    }
}