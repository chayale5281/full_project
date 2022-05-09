using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace full_project.Controllers
{
    public class DaysofworController : ApiController
    {
//#pragma warning disable IDE0044 // Add readonly modifier
        Daysofworbll db = new Daysofworbll();
//#pragma warning restore IDE0044 // Add readonly modifier
        // GET: api/Daysofwor
        public Object Get()
        {
            var res = db.GetAllDaysWor();
            return res.Data;
        }

        // GET: api/Daysofwor/5
        public string Get(int id)
        {
            Seconde s = new Seconde();
            s.TheSecond();
            return "value";
        }

        // POST: api/Daysofwor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Daysofwor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Daysofwor/5
        public void Delete(int id)
        {
        }
    }
}
