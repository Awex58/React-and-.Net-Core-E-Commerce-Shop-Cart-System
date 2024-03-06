using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.DataAccess.EntityFrameworkDal.Concrete;
using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Core.Entities.Results;
using Case1.Services.Abstract;

namespace Case1.Services.Concrete
{
    public class SalesProductsService : ISalesProductsService
    {
        private ISalesProductsDal _SalesProductsDal;
        private ICartDal _CartDal;
        private IProductDal _ProductDal;
        public SalesProductsService(ISalesProductsDal _psdal, ICartDal cartDal, IProductDal productDal)
        {
            _SalesProductsDal = _psdal;
            _CartDal = cartDal;
            _ProductDal = productDal;
        }
        public IDataResult<List<SalesProducts>> GetAllSalesProducts()
        {
            return new SuccessDataResult<List<SalesProducts>>(_SalesProductsDal.GetAllSalesProducts());
        }

        public IResultt Add(SaledDto saled) // cart satışı tamamlandığında çalışır
        {
            var userforcarts = _CartDal.GetUserCart(saled.UserId);
            var soldProducts = new List<SalesProducts>();

            foreach (var cartItem in userforcarts)
            {
                var product = _ProductDal.Get(x=>x.ProductId == cartItem.ProductId);
                if (product != null)
                {
                    // Satış geçmişi için kayıt oluştur
                    var soldProduct = new SalesProducts
                    {
                        SaleAddress = saled.DeliveryAddress,
                        SaleAmount = cartItem.ProductAmount,
                        SaleUserId = saled.UserId,
                        SalePrice = product.ProductPrice,
                        CategoryId = product.ProductCategoryId,
                        SaleProductName = product.ProductName
                    };
                    soldProducts.Add(soldProduct);

                    // Ürün adedini düşür
                    product.ProductAmount -= cartItem.ProductAmount;
                    if (product.ProductAmount <= 0)
                    {
                        // Ürün adedi sıfıra düşerse, ürünü sil
                        _ProductDal.Delete(product);
                    }
                    else
                    {
                        // Ürünü güncelle
                        _ProductDal.Update(product);
                    }
                }

                // Sepeti temizle
                _CartDal.Delete(cartItem);
            }

            // Satılan ürünleri kaydet
            foreach (var soldProduct in soldProducts)
            {
                _SalesProductsDal.Add(soldProduct);
            }

            return new SuccessResult("Satış Geçmişi Başarıyla Eklendi!");
        }
    }
}
