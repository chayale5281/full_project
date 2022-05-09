using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace full_project.Controllers
{
    public class ConstraintsforeigenworkerDtoController : ApiController
    {
#pragma warning disable IDE0044 // Add readonly modifier
        Constraintsforeigenworkerbll db = new Constraintsforeigenworkerbll();
#pragma warning restore IDE0044 // Add readonly modifier
        // GET: api/ConstraintsforeigenworkerDto
        public Object Get()
        {
            var res = db.GetAllConstraintsforeigenworker();
            return res.Data;
            
        }



        // GET: api/ConstraintsforeigenworkerDto/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ConstraintsforeigenworkerDto
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ConstraintsforeigenworkerDto/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ConstraintsforeigenworkerDto/5
        public void Delete(int id)
        {
        }
        public void theseconde()
        {
            Seconde s = new Seconde();
            s.TheSecond();
        }
    }
}
