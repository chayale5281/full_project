using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
  public  class Foreign_workerbll
    {
        public RequestResult GetAllforeign_worer()
        {
            using (dbEntities db = new dbEntities())
            {
                List<Foreign_workerDto> lst = new List<Foreign_workerDto>();
                foreach (var item in db.Foreign_worker.ToList())
                    lst.Add(Foreign_workerDto.DalToDto(item));
                return new RequestResult()
                {
                    Data = lst,
                    Message = "succesfull",
                    status = true
                };
            }
        }
        public void Addforeign_worer(Foreign_workerDto fw)
        {
            using (dbEntities db = new dbEntities())
            {
                db.Foreign_worker.Add(fw.DtoToDal());
                db.SaveChanges();
            }
        }
    }
}
