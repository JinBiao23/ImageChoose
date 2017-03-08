using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageChoose.Startup))]
namespace ImageChoose
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
