using Case1.Core.Entities.Concrete;
using Case1.Data.Respository;

namespace Case1.Core.DataAccess.EntityFrameworkDal.Abstract
{
    public interface ICartDal : IEntityRespository<Cart>
    {
        List<Cart> GetUserCart(int userid);
    }
}
