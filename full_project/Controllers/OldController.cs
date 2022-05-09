using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace full_project.Controllers
{
    public class OldController : ApiController
    {
#pragma warning disable IDE0044 // Add readonly modifier
        oldbll db = new oldbll();
#pragma warning restore IDE0044 // Add readonly modifier
        // GET: api/Old
        public Object Get()
        {
            var res = db.GetAllOld();
            return res.Data;

        }

        // GET: api/Old/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Old
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Old/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Old/5
        public void Delete(int id)
        {
        }
    }
}
