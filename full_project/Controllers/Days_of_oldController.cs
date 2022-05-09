using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace full_project.Controllers
{
    public class Days_of_oldController : ApiController
    {
#pragma warning disable IDE0044 // Add readonly modifier
        Days_of_oldbll db = new Days_of_oldbll();
#pragma warning restore IDE0044 // Add readonly modifier
        // GET: api/Days_of_old
        public Object Get()
        {
            db.GetAllDaysOld();
            var res = db.GetAllDaysOld();
            return res.Data;
        }

        // GET: api/Days_of_old/5
        public string Get(int id)
        {
            db.GetAllDaysOld();
            return "value";
        }

        // POST: api/Days_of_old
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Days_of_old/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Days_of_old/5
        public void Delete(int id)
        {
        }
    }
}
