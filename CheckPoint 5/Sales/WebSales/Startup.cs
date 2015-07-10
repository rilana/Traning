using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSales.Startup))]
namespace WebSales
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
