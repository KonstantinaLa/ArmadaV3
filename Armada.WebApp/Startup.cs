using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Armada.WebApp.Startup))]
namespace Armada.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
