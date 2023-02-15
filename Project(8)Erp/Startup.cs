using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_8_Erp.Startup))]
namespace Project_8_Erp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
