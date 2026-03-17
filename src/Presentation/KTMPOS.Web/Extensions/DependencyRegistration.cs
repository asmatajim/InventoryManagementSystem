namespace KTMPOS.Web.Extensions
{
    public static class DependencyRegistration
    {
        public static void AddPresentationLayer(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";

                // Secure cookie settings
                options.Cookie.HttpOnly = true; // Prevent JavaScript access to the cookie
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Require HTTPS for the cookie
                options.Cookie.SameSite = SameSiteMode.Strict; // Prevent cross-site cookie usage
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5); // Set the expiration time for the cookie
                options.SlidingExpiration = true; // Refresh the expiration time on each request
            });
        }
    }
}