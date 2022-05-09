using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
   public class Days_of_oldbll
    {
        public RequestResult GetAllDaysOld()
        {
            using (dbEntities db = new dbEntities())
            {
                List<Days_of_old2Dto> lst = new List<Days_of_old2Dto>();
                foreach (var item in db.days_of_old2.ToList())
                    lst.Add(Days_of_old2Dto.DalToDto(item));
                return new RequestResult()
                {
                    Data = lst,
                    Message = "succesfull",
                    status = true
                };
            }
        }
        public void AddDaysOld(Days_of_old2Dto dfo)
        {
            using (dbEntities db = new dbEntities())
            {
                db.days_of_old2.Add(dfo.DtoToDal());
                db.SaveChanges();
            }
        }
    }
}
