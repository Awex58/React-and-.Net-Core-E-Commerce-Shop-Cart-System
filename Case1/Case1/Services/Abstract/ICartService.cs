using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Core.Entities.Results;

namespace Case1.Services.Abstract
{
    public interface ICartService
    {
        IResultt Add(Cart cart);
        IResultt Delete(Cart cart);
        IResultt Update(Cart cart);
        IResultt AddCart(CartDto cartDto);
        IDataResult<List<CartDto>> GetUserCart(int userid);


    }
}
