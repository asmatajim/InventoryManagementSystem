using KTMPOS.Desktop.Forms;
using KTMPOS.Desktop.Forms.Childs.Inventory;
using KTMPOS.Desktop.Forms.Childs.POS;
using KTMPOS.Desktop.Forms.Childs.PurchaseBilling;
using KTMPOS.Desktop.Forms.Childs.Reporting;

using Microsoft.Extensions.DependencyInjection;

namespace KTMPOS.Desktop.Extensions
{
    public static class DependencyRegistration
    {
        public static void AddDesktopLayer(this IServiceCollection services)
        {
            services.AddScoped<LoginForm>();
            services.AddScoped<POSMainForm>();
            services.AddScoped<CategoryForm>();
            services.AddScoped<SubCategoryForm>();
            services.AddScoped<ProductForm>();
            services.AddScoped<SupplierForm>();
            services.AddScoped<PurchaseForm>();
            services.AddScoped<SalesForm>();
            services.AddScoped<SalesReportForm>();
        }
    }
}