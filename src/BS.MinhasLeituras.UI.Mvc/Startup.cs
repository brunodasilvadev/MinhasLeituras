using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BS.MinhasLeituras.UI.Mvc.Startup))]
namespace BS.MinhasLeituras.UI.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
