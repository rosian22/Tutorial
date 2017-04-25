using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SitulClasei.Startup))]
namespace SitulClasei
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
