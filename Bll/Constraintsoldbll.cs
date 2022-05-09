using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bll
{
  public  class Constraintsoldbll
    {
        public void AddConstraintsforeigenworker(ConstraintsforeigenworkerDto cw)
        {
            using (dbEntities db = new dbEntities())
            {
                db.Constraintsforeigenworker.Add(cw.DtoToDal());
                db.SaveChanges();
            }
        }
        public RequestResult GetAllConstraintsoldDto()
        {
            using (dbEntities db = new dbEntities())
            {
                List<ConstraintsoldDto> lst = new List<ConstraintsoldDto>();
                foreach (var item in db.Constraintsold.ToList())
                    lst.Add(ConstraintsoldDto.DalToDto(item));
                return new RequestResult()
                {
                    Data = lst,
                    Message = "succesfull",
                    status = true
                };
            }
        }
        public void AddConstraintsoldDto(ConstraintsoldDto co)
        {
            using (dbEntities db = new dbEntities())
            {
                db.Constraintsold.Add(co.DtoToDal());
                db.SaveChanges();
            }
        }
        public static ConstraintsoldDto Login(ConstraintsoldDto cono,OldDto ol)
        {
            using (dbEntities db = new dbEntities())
            {
                ConstraintsoldDto co = ConstraintsoldDto.DalToDto(db.Constraintsold.FirstOrDefault(c => c.passwardold == cono.passwardold));
                OldDto oldo = OldDto.DalToDto(db.old.FirstOrDefault(o => o.fnameold == o.fnameold));
                if (co != null && oldo != null)
                    return co;
                else
                {
                    if (co == null)
                        return co;
                    else { 
                        co = null;
                        return co;
                    }
                }
            }
        }
    }
}
