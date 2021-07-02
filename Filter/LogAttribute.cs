

using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FilterWebApi.Filter
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            string rawRequest;
            using (var stream = new StreamReader(actionContext.Request.Content.ReadAsStreamAsync().Result))
            {
                stream.BaseStream.Position = 0;
                rawRequest = stream.ReadToEnd();
            }
            Logger.WriteLogFile("Request Received : " + rawRequest);
            
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            string response;
            using (var stream = new StreamReader(actionExecutedContext.Response.Content.ReadAsStreamAsync().Result))
            {
                stream.BaseStream.Position = 0;
                response = stream.ReadToEnd();
            }
            Logger.WriteLogFile("Response Sent : " + response);
        }

       
    }
}