using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Results;
using System.Diagnostics;

namespace Case1.Services.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAllProduct();
        IDataResult<List<Product>> GetCategoryProduct(int categoryid);
        IDataResult<Product> GetProduct(int productid);
        IResultt Add(Product product);
        IResultt Delete(Product product);
        IResultt Update(Product product);
    }
}
