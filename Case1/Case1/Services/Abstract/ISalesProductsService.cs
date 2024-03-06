using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Core.Entities.Results;

namespace Case1.Services.Abstract
{
    public interface ISalesProductsService
    {
        IDataResult<List<SalesProducts>> GetAllSalesProducts();
        IResultt Add(SaledDto saledDto);
    }
}
