using KTMPOS.BAL.Extensions;
using KTMPOS.Common.Constants;
using KTMPOS.DAL.Extensions;
using KTMPOS.Web.Extensions;

namespace KTMPOS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(Policy.UserCreate, policy => policy.RequireRole(Role.Admin));
                options.AddPolicy(Policy.InventoryListOrCreate, policy => policy.RequireRole(Role.Admin, Role.Manager, Role.Inventory));
                options.AddPolicy(Policy.InventoryEditOrDelete, policy => policy.RequireRole(Role.Admin, Role.Manager));
                options.AddPolicy(Policy.PurchaseEntry, policy => policy.RequireRole(Role.Admin, Role.Manager));
                options.AddPolicy(Policy.SalesEntry, policy => policy.RequireRole(Role.Admin, Role.Manager, Role.Sales));
                options.AddPolicy(Policy.Reporting, policy => policy.RequireRole(Role.Admin, Role.Manager));
            });

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDAL(connectionString);
            builder.Services.AddBAL();
            builder.Services.AddPresentationLayer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}