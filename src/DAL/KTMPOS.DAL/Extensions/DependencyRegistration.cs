using KTMPOS.DAL.Data;
using KTMPOS.DAL.Entities.Users;
using KTMPOS.DAL.Repositories.Dapper;
using KTMPOS.DAL.Repositories.Inventory.Categories;
using KTMPOS.DAL.Repositories.Inventory.Products;
using KTMPOS.DAL.Repositories.Inventory.SubCategories;
using KTMPOS.DAL.Repositories.POS;
using KTMPOS.DAL.Repositories.PurchaseBilling;
using KTMPOS.DAL.Repositories.Reporting;
using KTMPOS.DAL.Repositories.Users;
using KTMPOS.DAL.Utilities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KTMPOS.DAL.Extensions
{
    public static class DependencyRegistration
    {
        public static void AddDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<IDapperRepository>(x => new DapperRepository(connectionString));
            services.AddScoped<ISalesReportRepository, SalesReportRepository>();
            services.AddScoped<ITransactionManager, DbContextTransactionManager>();
        }
    }
}