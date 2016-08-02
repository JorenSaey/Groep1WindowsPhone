using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TravelListServiceService.Startup))]

namespace TravelListServiceService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}