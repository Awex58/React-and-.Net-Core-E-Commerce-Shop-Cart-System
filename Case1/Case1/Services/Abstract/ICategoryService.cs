using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Results;

namespace Case1.Services.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Categories>> GetAllCategories();
        IResultt Add(Categories category);
        IResultt Delete(Categories category);
        IResultt Update(Categories category);
    }
}
