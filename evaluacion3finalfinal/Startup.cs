using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(evaluacion3finalfinal.Startup))]
namespace evaluacion3finalfinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
