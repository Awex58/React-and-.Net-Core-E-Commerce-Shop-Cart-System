using Case1.Core.Entities.Concrete;
using Case1.Data.Respository;
using System.Diagnostics;

namespace Case1.Core.DataAccess.EntityFrameworkDal.Abstract
{
    public interface IProductDal : IEntityRespository<Product>
    {
        List<Product> GetAllProduct();
        List<Product> GetCategoryProduct(int categoryid);
    }
}
