using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssetTrackingSystem.MVC.Startup))]
namespace AssetTrackingSystem.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
