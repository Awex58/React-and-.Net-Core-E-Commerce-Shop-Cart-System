using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.DataAccess.EntityFrameworkDal.Concrete;
using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Results;
using Case1.Services.Abstract;
using System.Diagnostics;

namespace Case1.Services.Concrete
{
    public class ProductService: IProductService
    {
        private IProductDal _ProductDal;
        public ProductService(IProductDal _pdal)
        {
            _ProductDal = _pdal;
        }


        public IDataResult<List<Product>> GetAllProduct()
        {
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAllProduct());
        }

        public IDataResult<List<Product>> GetCategoryProduct(int categoryid)
        {
            return new SuccessDataResult<List<Product>>(_ProductDal.GetAllProduct());
        }
        public IDataResult<Product> GetProduct(int productid)
        {
            return new SuccessDataResult<Product>(_ProductDal.Get(x=>x.ProductId==productid));
        }
        public IResultt Add(Product product)
        {
            _ProductDal.Add(product);
            return new SuccessResult("Ürün Başarıyla Eklendi!");
        }

        public IResultt Delete(Product product)
        {
            _ProductDal.Delete(product);
            return new SuccessResult("Ürün Başarıyla Silindi!");
        }

        public IResultt Update(Product product)
        {
            _ProductDal.Update(product);
            return new SuccessResult("Ürün Başarıyla Güncellendi!");
        }




    }


}
