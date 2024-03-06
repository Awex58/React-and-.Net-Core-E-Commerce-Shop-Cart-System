using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.Entities.Concrete;
using Case1.Data.DbContext;
using Case1.Data.Respository;

namespace Case1.Core.DataAccess.EntityFrameworkDal.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Categories, dbContext>, ICategoryDal
    {
        public List<Categories> GetAllCategory()
        {
            using (var context = new dbContext())
            {
                var all = context.CATEGORIES.Select(x => new Categories
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,  
                    

                }).ToList();

                return all;
            }


        }
    }
}
