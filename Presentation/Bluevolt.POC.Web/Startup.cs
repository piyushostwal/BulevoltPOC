using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bluevolt.POC.Web.Startup))]
namespace Bluevolt.POC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
