using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FilterWebApi.Filter
{
    public class CustomAuthenticationFilter: ActionFilterAttribute,IActionFilter
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            NameValueCollection oamHeaders = HttpContext.Current.Request.Headers;
            // var userId = Convert.ToString(httpContext.Session["UserId"]);
            string userId = oamHeaders.Get("x-uid");
            // pre-processing
            Debug.WriteLine("ACTION 1 DEBUG pre-processing logging");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
            }

            Debug.WriteLine("ACTION 1 DEBUG  OnActionExecuted Response " + actionExecutedContext.Response.StatusCode.ToString());
        }

        //public override void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    //This is where you will add any custom logging code
        //    //that will execute before your method runs.
        //    //Log.DebugFormat(string.Format("Request {0} {1}"
        //    //   , actionContext.Request.Method.ToString()
        //    //      , actionContext.Request.RequestUri.ToString());
        //}

        ////This function will execute after the web api controller

        //public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        //{
        //    //This is where you will add any custom logging code that will
        //    ////execute after your method runs.
        //    //Log.DebugFormat(string.Format("{0} Response Code: {1}"
        //    //           , actionExecutedContext.Request.RequestUri.ToString()
        //    //              , actionExecutedContext.Response.StatusCode.ToString());
        //}
        //public void OnAuthentication(AuthenticationContext filterContext)
        //{
        //    if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserName"])))
        //    {
        //        filterContext.Result = new HttpUnauthorizedResult();
        //    }
        //}
        //public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        //{
        //    if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
        //    {
        //        //Redirecting the user to the Login View of Account Controller
        //        filterContext.Result = new RedirectToRouteResult(
        //        new RouteValueDictionary
        //        {
        //             { "controller", "Account" },
        //             { "action", "Login" }
        //        });
        //    }
        //}
    }
}