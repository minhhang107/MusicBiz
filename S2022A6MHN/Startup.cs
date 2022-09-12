using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S2022A6MHN.Startup))]
namespace S2022A6MHN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
