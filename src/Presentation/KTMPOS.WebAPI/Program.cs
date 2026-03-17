using KTMPOS.BAL.Extensions;
using KTMPOS.DAL.Extensions;

namespace KTMPOS.WebAPI
{
    public class Program
    {
        private const string _corsPolicy = "AllowSpecificOrigin";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicy,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7069");
                    });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDAL(connectionString);
            builder.Services.AddBAL();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseCors(_corsPolicy);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}