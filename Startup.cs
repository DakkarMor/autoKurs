using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kursovik.Startup))]
namespace kursovik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
