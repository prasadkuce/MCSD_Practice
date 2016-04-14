using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCSD_Practice.Olympic_Marathon_Runners.Startup))]
namespace MCSD_Practice.Olympic_Marathon_Runners
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
