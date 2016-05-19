using Owin;
using System.Web.Http;

namespace WebApiOwinTesting
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            appBuilder.UseWebApi(config);
        }
    }
}
