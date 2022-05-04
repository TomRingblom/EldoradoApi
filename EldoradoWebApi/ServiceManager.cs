using EldoradoWebApi.Services;

namespace EldoradoWebApi;

public static class ServiceManager
{
    public static void AddScopedServices(this IServiceCollection service)
    {
        service.AddScoped<IBrandService, BrandService>();
        service.AddScoped<ICategoryService, CategoryService>();
        service.AddScoped<IColorService, ColorService>();
        service.AddScoped<ICouponService, CouponService>();
        service.AddScoped<IOrderDetailsService, OrderDetailsService>();
        service.AddScoped<IOrderService, OrderService>();
        service.AddScoped<IProductService, ProductsService>();
        service.AddScoped<ISizeService, SizeService>();
        service.AddScoped<IStatusService, StatusService>();
        service.AddScoped<ISubCategoryService, SubCategoryService>();
    }
}