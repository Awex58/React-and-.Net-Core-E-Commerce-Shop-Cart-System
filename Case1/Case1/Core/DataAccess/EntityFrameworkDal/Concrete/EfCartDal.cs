using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.Entities.Concrete;
using Case1.Data.DbContext;
using Case1.Data.Respository;

namespace Case1.Core.DataAccess.EntityFrameworkDal.Concrete
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, dbContext>, ICartDal
    {
        public List<Cart> GetUserCart(int userid)
        {
            using (var context = new dbContext())
            {
                var all = context.CARTS.Where(x => x.UserId == userid).Select(x => new Cart
                {
                   CartId = x.CartId,
                   ProductAmount = x.ProductAmount,
                   UserId = x.UserId,
                   ProductId = x.ProductId

                }).ToList();

                return all;
            }

        }
    }
}
