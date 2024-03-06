using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.Entities.Concrete;
using Case1.Data.DbContext;
using Case1.Data.Respository;
using System.Diagnostics;

namespace Case1.Core.DataAccess.EntityFrameworkDal.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, dbContext>, IProductDal
    {
        public List<Product> GetAllProduct()
        {
            using (var context = new dbContext())
            {
                var all = context.PRODUCTS.Select(x => new Product
                {
                    ProductId = x.ProductId,
                    ProductAmount = x.ProductAmount,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductDescription = x.ProductDescription,
                    ProductName = x.ProductName,
                    ProductPicture = x.ProductPicture,
                    ProductPrice = x.ProductPrice

                }).ToList();

                return all;
            }


        }


        public List<Product> GetCategoryProduct(int categoryid)
        {
            using (var context = new dbContext())
            {
                var all = context.PRODUCTS.Where(x=> x.ProductCategoryId == categoryid).Select(x => new Product
                {
                    ProductId = x.ProductId,
                    ProductAmount = x.ProductAmount,
                    ProductCategoryId = x.ProductCategoryId,
                    ProductDescription = x.ProductDescription,
                    ProductName = x.ProductName,
                    ProductPicture = x.ProductPicture,
                    ProductPrice = x.ProductPrice

                }).ToList();

                return all;
            }

        }
    }
}
