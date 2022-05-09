using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
    public class oldbll
    {
        public RequestResult GetAllOld()
        {
            using (dbEntities db = new dbEntities())
            {
                List<OldDto> lst = new List<OldDto>();
                foreach (var item in db.old.ToList())
                    lst.Add(OldDto.DalToDto(item));
                return new RequestResult()
                {
                    Data = lst,
                    Message = "succesfull",
                    status = true
                };
            }
        }
        public void AddOldDto(OldDto o)
        {
            using (dbEntities db = new dbEntities())
            {
                db.old.Add(o.DtoToDal());
                db.SaveChanges();
            }
        }
    }
}
