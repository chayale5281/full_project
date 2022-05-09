using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;

namespace Bll
{
  public  class Constraintsforeigenworkerbll
    {
        public RequestResult GetAllConstraintsforeigenworker()
        {
            using (dbEntities db = new dbEntities())
            {
                List<ConstraintsforeigenworkerDto> lst = new List<ConstraintsforeigenworkerDto>();
                foreach (var item in db.Constraintsforeigenworker.ToList())
                    lst.Add(ConstraintsforeigenworkerDto.DalToDto(item));
                return new RequestResult()
                {
                    Data = lst,
                    Message = "succesfull",
                    status = true
                };
            }
        }
        public void AddConstraintsforeigenworker(ConstraintsforeigenworkerDto cw)
        {
            using (dbEntities db = new dbEntities())
            {
                db.Constraintsforeigenworker.Add(cw.DtoToDal());
                db.SaveChanges();
            }
        }
    }
}
