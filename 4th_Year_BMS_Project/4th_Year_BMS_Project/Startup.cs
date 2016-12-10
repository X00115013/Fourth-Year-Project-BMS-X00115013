using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4th_Year_BMS_Project.Startup))]
namespace _4th_Year_BMS_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
