using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gimnasios.Startup))]
namespace Gimnasios
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
