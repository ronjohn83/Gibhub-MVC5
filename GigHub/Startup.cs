using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GigHub4.Startup))]
namespace GigHub4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
