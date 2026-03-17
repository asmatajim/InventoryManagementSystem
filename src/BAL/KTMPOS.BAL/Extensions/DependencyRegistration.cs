using FluentValidation;

using KTMPOS.BAL.Services.Inventory.Categories;
using KTMPOS.BAL.Services.Inventory.Products;
using KTMPOS.BAL.Services.Inventory.SubCategories;
using KTMPOS.BAL.Services.POS;
using KTMPOS.BAL.Services.PurchaseBilling;
using KTMPOS.BAL.Services.Reporting;
using KTMPOS.BAL.Services.Users;
using KTMPOS.BAL.Validators.Users;

using Microsoft.Extensions.DependencyInjection;

namespace KTMPOS.BAL.Extensions
{
    public static class DependencyRegistration
    {
        public static void AddBAL(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<ISalesReportService, SalesReportService>();
        }
    }
}