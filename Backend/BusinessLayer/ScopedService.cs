
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer;

public static class ScopedService
{
    public static void ContainerDependencies(this IServiceCollection services)

    {
        
        services.AddScoped<IAboutDal, EfAboutDal>();
        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<IBookingDal, EfBookingDal>();
        services.AddScoped<IBookingService, BookingManager>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IProductDal, EfProductDal>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<IDiscountDal, EfDiscountDal>();
        services.AddScoped<IDiscountService, DiscountManager>();
        services.AddScoped<IFeatureDal, EfFeatureDal>();
        services.AddScoped<IFeatureService, FeatureManager>();
        services.AddScoped<ISignalRStatisticDal, EfSignalRStatisticDal>();
        services.AddScoped<ISignalRStatisticService, SignalRStatisticManager>();
        services.AddScoped<IOrderDal, EfOrderDal>();
        services.AddScoped<IOrderService, OrderManager>();
        services.AddScoped<IOrderDetailsDal, EfOrderDetailsDal>();
        services.AddScoped<IOrderDetailsService, OrderDetailsManager>();

        services.AddScoped<IShoppingCartDal, EfShoppingCartDal>();
        services.AddScoped<IShoppingCartService, ShoppingCartManager>();
        
        services.AddScoped<IDiningTableDal, EfDiningTableDal>();
        services.AddScoped<IDiningTableService, DiningTableManager>();


    }
    
    
}