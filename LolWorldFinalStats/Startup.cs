using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LolWorldFinalStats.Startup))]
namespace LolWorldFinalStats
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
