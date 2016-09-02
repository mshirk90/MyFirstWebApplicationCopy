using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstWebApplication.Startup))]
namespace MyFirstWebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
