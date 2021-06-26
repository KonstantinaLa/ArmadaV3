using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArmadaV3.WebApp.Startup))]
namespace ArmadaV3.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
