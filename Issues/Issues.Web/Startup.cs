using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Issues.Web.Startup))]
namespace Issues.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
