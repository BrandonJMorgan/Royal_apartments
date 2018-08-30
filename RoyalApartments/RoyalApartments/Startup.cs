using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoyalApartments.Startup))]
namespace RoyalApartments
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
