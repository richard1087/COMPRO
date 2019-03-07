using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COMPRO.Startup))]
namespace COMPRO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
