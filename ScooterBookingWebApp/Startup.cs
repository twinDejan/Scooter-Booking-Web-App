using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScooterBookingWebApp.Startup))]
namespace ScooterBookingWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
