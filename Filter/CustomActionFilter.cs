using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FilterWebApi.Filter
{
    public class CustomActionFilter : ActionFilterAttribute
    {
       
        public override void OnActionExecuting(HttpActionContext actionContext)
        {            
            NameValueCollection oamHeaders = HttpContext.Current.Request.Headers;            
            string userId = oamHeaders.Get("x-uid");
            string token = oamHeaders.Get("x-token");
            Logger.WriteLogFile("OnActionExecuted Request  : " + actionContext.Request.RequestUri.ToString());
            if (!verifyUser(userId, token))
            {
                actionContext.Response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("Unauthorized User")
                };
                Logger.WriteLogFile("OnActionExecuted Response  : " + actionContext.Response.StatusCode.ToString());
               
            }
          
            base.OnActionExecuting(actionContext);
            // pre-processing

        }
        
        private bool verifyUser(string user, string usertoken)
        {
            string username = "abc"; string token = "123";
            
            if (username == user && token == usertoken)
            {
                Logger.WriteLogFile("On Action Executing Authorized UserName : " + username );
                return true;
            }
            else
            {
                Logger.WriteLogFile("User is not Authorized UserName : " + username );
                return false;
            }
          
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
            }
            Logger.WriteLogFile("OnActionExecuted Response  : " + actionExecutedContext.Response.StatusCode.ToString());
            
        }


     



    }
}