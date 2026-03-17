using KTMPOS.BAL.Extensions;
using KTMPOS.DAL.Extensions;
using KTMPOS.Desktop.Extensions;
using KTMPOS.Desktop.Forms;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KTMPOS.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            ApplicationConfiguration.Initialize();
            LoginForm form = host.Services.GetRequiredService<LoginForm>();
            Application.Run(form);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
           .ConfigureAppConfiguration((hostingContext, config) =>
           {
               config
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
           })
           .ConfigureServices((hostContext, services) =>
           {
               string connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
               services.AddDAL(connectionString);
               services.AddBAL();
               services.AddDesktopLayer();
           });
    }
}