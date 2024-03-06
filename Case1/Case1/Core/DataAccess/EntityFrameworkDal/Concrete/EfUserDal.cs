using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.Entities.Concrete;
using Case1.Data.DbContext;
using Case1.Data.Respository;

namespace Case1.Core.DataAccess.EntityFrameworkDal.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, dbContext>, IUserDal
    {
    }
}
