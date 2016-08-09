using PackingListService.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace PackingListService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register();
            MobileServiceContext mbc = new MobileServiceContext();
            mbc.Users.ToList();
        }
    }
}