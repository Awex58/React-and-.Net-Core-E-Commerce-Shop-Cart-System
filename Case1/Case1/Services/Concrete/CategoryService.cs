using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.DataAccess.EntityFrameworkDal.Concrete;
using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Results;
using Case1.Services.Abstract;

namespace Case1.Services.Concrete
{
    public class CategoryService:ICategoryService
    {
        private ICategoryDal _CategoryDal;
        public CategoryService(ICategoryDal categorydal)
        {
            _CategoryDal = categorydal;
        }
        public IDataResult<List<Categories>> GetAllCategories()
        {
            return new SuccessDataResult<List<Categories>>(_CategoryDal.GetAllCategory());
        }

        public IResultt Add(Categories category)
        {
            _CategoryDal.Add(category);
            return new SuccessResult("Kategori Başarıyla Eklendi!");
        }

        public IResultt Delete(Categories category)
        {
            _CategoryDal.Delete(category);
            return new SuccessResult("Kategori Başarıyla Silindi!");
        }

        public IResultt Update(Categories category)
        {
            _CategoryDal.Update(category);
            return new SuccessResult("Kategori Başarıyla Güncellendi!");
        }
    }
}
