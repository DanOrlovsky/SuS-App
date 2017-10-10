using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuS.Web.Startup))]
namespace SuS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
