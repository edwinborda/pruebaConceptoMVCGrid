using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Authorization.Infrastructure;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(PruebaConcepto.WebApp.Startup))]

namespace PruebaConcepto.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Index"),
            });
            
            app.UseAuthorization(options =>
            {
                options.AddPolicy("IsEditable", policy => policy.RequireClaim("IsEditable","True"));
            });
        }
    }
}
