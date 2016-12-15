using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RevaShare.DataAccess.Startup))]
namespace RevaShare.DataAccess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
