using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet;
using Microsoft.Owin;
using System.Web.Http;
using Owin;
using System.Web.Http.Cors;
using BasicAuthentication;

[assembly: OwinStartup(typeof(Webcam_WS.Startup))]
namespace Webcam_WS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                //defaults: new { controller = "Start", id = RouteParameter.Optional }
            );
            //enable CORS
            var cors = new EnableCorsAttribute("*", "*", methods:"post");
            config.EnableCors(cors);
            config.Filters.Add(new BasicAuthenticationAttribute());
            app.UseWebApi(config);
        }
    }
}
