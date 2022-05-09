using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
   public class Daysofworbll
    {
        public RequestResult GetAllDaysWor()
        {
            using (dbEntities db = new dbEntities())
            {
                List<Days_of_wor2Dto> lst = new List<Days_of_wor2Dto>();
                foreach (var item in db.days_of_wor2.ToList())
                    lst.Add(Days_of_wor2Dto.DalToDto(item));
                return new RequestResult()
                {
                    Data = lst,
                    Message = "succesfull",
                    status = true
                };
            }
        }
        public void AddDaysWor(Days_of_wor2Dto dfw)
        {
            using (dbEntities db = new dbEntities())
            {
                db.days_of_wor2.Add(dfw.DtoToDal());
                db.SaveChanges();
            }
        }
    }
}
