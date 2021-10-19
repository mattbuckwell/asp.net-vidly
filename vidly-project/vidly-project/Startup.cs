using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vidly_project.Startup))]
namespace vidly_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
