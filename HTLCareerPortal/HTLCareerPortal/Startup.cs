using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HTLCareerPortal.Startup))]
namespace HTLCareerPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
