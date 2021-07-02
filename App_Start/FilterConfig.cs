using FilterWebApi.Filter;
using System.Web;
using System.Web.Mvc;

namespace FilterWebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           
        }
    }
}
