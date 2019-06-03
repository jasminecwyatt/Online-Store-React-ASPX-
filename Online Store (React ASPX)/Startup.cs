using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Online_Store__React_ASPX_.Startup))]
namespace Online_Store__React_ASPX_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
