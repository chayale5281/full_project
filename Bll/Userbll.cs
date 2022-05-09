using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bll
{
   public class Userbll
    {
        public static object Login(UserDto u)
        {
            using (dbEntities db = new dbEntities())
            {
                ConstraintsoldDto co = ConstraintsoldDto.DalToDto(db.Constraintsold.FirstOrDefault(c => c.passwardold == u.Password &&c.mail==u.Name));
                ConstraintsforeigenworkerDto cw= ConstraintsforeigenworkerDto.DalToDto(db.Constraintsforeigenworker.FirstOrDefault(c => c.passwardwor == u.Password && c.mail == u.Name));
                if (co != null)
                    return co;
                else
                {
                    if (cw != null)
                        return cw;
                    else
                    {
                        co = null;
                        return co;
                    }
                }
            }
        }
    }
}
