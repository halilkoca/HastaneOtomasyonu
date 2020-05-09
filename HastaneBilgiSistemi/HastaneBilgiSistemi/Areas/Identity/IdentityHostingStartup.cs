using HastaneBilgiSistemi.Cache;
using HastaneBilgiSistemi.CookieOptions;
using HastaneBilgiSistemi.Data;
using HastaneBilgiSistemi.Data.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

[assembly: HostingStartup(typeof(HastaneBilgiSistemi.Areas.Identity.IdentityHostingStartup))]
namespace HastaneBilgiSistemi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                


                services.Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

                services.AddTransient<ITicketStore, InMemoryTicketStore>();
                services.AddSingleton<IPostConfigureOptions<CookieAuthenticationOptions>,
                  ConfigureCookieAuthenticationOptions>();

                services.ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = $"/Identity/Account/Login";
                    options.LogoutPath = $"/Identity/Account/Logout";
                    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                });
            });
        }
    }
}