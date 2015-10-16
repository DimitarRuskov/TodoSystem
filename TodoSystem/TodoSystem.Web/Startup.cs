using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoSystem.Web.Startup))]
namespace TodoSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
