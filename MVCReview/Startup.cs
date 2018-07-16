using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCReview.Startup))]
namespace MVCReview
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
