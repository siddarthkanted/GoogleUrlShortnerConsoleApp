using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoogleUrlShortnerWebApplication.Startup))]
namespace GoogleUrlShortnerWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
