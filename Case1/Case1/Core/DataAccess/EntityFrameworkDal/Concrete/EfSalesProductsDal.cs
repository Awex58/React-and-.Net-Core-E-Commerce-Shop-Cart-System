using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.Entities.Concrete;
using Case1.Data.DbContext;
using Case1.Data.Respository;

namespace Case1.Core.DataAccess.EntityFrameworkDal.Concrete
{
    public class EfSalesProductsDal : EfEntityRepositoryBase<SalesProducts, dbContext>, ISalesProductsDal
    {
        public List<SalesProducts> GetAllSalesProducts()
        {
            using (var context = new dbContext())
            {
                var all = context.SALESPRODUCTS.Select(x => new SalesProducts
                {
                    SaleId = x.SaleId,
                    SaleProductName = x.SaleProductName,
                    SaleUserId = x.SaleUserId,
                    CategoryId = x.CategoryId,
                    SaleTime = x.SaleTime,
                    SalePrice = x.SalePrice,
                    SaleAmount = x.SaleAmount,
                    SaleAddress = x.SaleAddress,
                    

                }).ToList();

                return all;
            }


        }
    }
}
