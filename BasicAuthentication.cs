using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthentication
{
    class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;
                
                //decodes the authentication token
                var decodeAuthToken = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                //splits the decoded authentication token using a colon ':'
                var arrUserNameandPassword = decodeAuthToken.Split(':');

                if (IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(arrUserNameandPassword[0]), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            
        }

        private bool IsAuthorizedUser(string Username, string Password)
        {
            //the username is set to "admin@DBKU" and password is "P@55w0rd123"
            return Username == "admin@sains" && Password == "P@55w0rd123";
        }
    }
}
