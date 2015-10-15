using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoSystem.Startup))]
namespace TodoSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
