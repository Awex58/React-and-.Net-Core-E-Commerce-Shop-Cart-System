using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.DataAccess.EntityFrameworkDal.Concrete;
using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Core.Entities.Results;
using Case1.Services.Abstract;

namespace Case1.Services.Concrete
{
    public class CartService : ICartService
    {
        private ICartDal _CartDal;
        private IProductDal _ProducttDal;
        public CartService(ICartDal cartdal, IProductDal ProducttDal)
        {
            _CartDal = cartdal;
            _ProducttDal = ProducttDal;
        }

        public IResultt Add(Cart cart)
        {
            _CartDal.Add(cart);
            return new SuccessResult("Cart Başarıyla Eklendi!");
        }

        public IResultt Delete(Cart cart)
        {
            _CartDal.Delete(cart);
            return new SuccessResult("Cart Başarıyla Silindi!");
        }

        public IResultt Update(Cart cart)
        {
            _CartDal.Update(cart);
            return new SuccessResult("Cart Başarıyla Güncellendi!");
        }
        public IResultt AddCart(CartDto cartdto) 

        {

            var data = _CartDal.Get(x => x.UserId == cartdto.UserId && x.ProductId == cartdto.ProductId); // cart ve user var ise  ürünü +1 liyorum

            if (data != null )
            {
                data.ProductAmount++;
                _CartDal.Update(data);
                return new SuccessResult("Cart Başarıyla Güncellendi!");
            }
            else // yok ise yeni cart oluşturuyorum
            {

                _CartDal.Add(new Cart { ProductAmount = 1, ProductId = cartdto.ProductId, UserId = cartdto.UserId }); 
                return new SuccessResult("Cart Başarıyla Eklendi!");

            }


        }
        public IDataResult<List<CartDto>> GetUserCart(int userid)
        {
            var carts = _CartDal.GetUserCart(userid);
            var products = _ProducttDal.GetAllProduct();

            var mergedList = (from cart in carts
                              join product in products on cart.ProductId equals product.ProductId
                              select new CartDto
                              {
                                  CartId = cart.CartId,
                                  UserId = cart.UserId ?? 0,
                                  ProductId = cart.ProductId,
                                  ProductAmount = cart.ProductAmount,
                                  ProductName = product.ProductName,
                                  ProductPrice = product.ProductPrice,
                                  ProductDescription = product.ProductDescription,
                                  ProductCategoryId = product.ProductCategoryId,
                                  ProductPicture = product.ProductPicture
                              }).ToList();

      


            return new SuccessDataResult<List<CartDto>>(mergedList);

        }
    }
}
