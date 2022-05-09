
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bll;
namespace full_project.Controllers
{
    public class citysController : ApiController
    {
#pragma warning disable IDE0044 // Add readonly modifier
        citybll db = new citybll();
#pragma warning restore IDE0044 // Add readonly modifier
        // GET api/values
        public Object Get()
        {
            var res = db.GetAllCity();
            return res.Data;
        }

        // GET api/values/5
        public void Get2()
        {
            Seconde s = new Seconde();
             s.TheSecond();
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
