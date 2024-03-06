using Autofac;
using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.DataAccess.EntityFrameworkDal.Concrete;
using Case1.Services.Abstract;
using Case1.Services.Concrete;

namespace Case1.Core.DependencyAutoFac
{
    public class WriterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CartService>().As<ICartService>();
            builder.RegisterType<EfCartDal>().As<ICartDal>();

            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<EfSalesProductsDal>().As<ISalesProductsDal>();
            builder.RegisterType<SalesProductsService>().As<ISalesProductsService>();
        }
    }
}
