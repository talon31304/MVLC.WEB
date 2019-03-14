using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVLC.MVC.Startup))]
namespace MVLC.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
