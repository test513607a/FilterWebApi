using FilterWebApi.Filter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace FilterWebApi.Controllers
{
    [LogAttribute]
    public class ValuesController : ApiController
    {
        // GET api/values
       
        [CustomActionFilter]        
        public ActionResult Get()
        {
            return null;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[CustomActionFilter]
        //public IEnumerable<string> Post([FromBody] string value)
        //{
        //    return "";
        //}
        [CustomActionFilter]      
        public IEnumerable<string> Post([FromBody] string value)
        {
            return new string[] { "value1", "value2" };
        }
        // PUT api/values/5
        [CustomActionFilter]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
