using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal;
namespace Dto
{
  public  class Days_of_oldDto
    {
        public Days_of_oldDto()
        {

        }
        public int iddayo { get; set; }
        public int idold { get; set; }
        public string dayo { get; set; }
        public Nullable<int> hourstarto { get; set; }
        public Nullable<int> hourendo { get; set; }
        public Nullable<int> conoID { get; set; }

        

        public static Days_of_oldDto DalToDto(days_of_old d)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<days_of_old, Days_of_oldDto>());
            var mapper = config.CreateMapper();
            return mapper.Map<Days_of_oldDto>(d);
        }
        public days_of_old DtoToDal()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Days_of_oldDto, days_of_old>());
            var mapper = config.CreateMapper();
            return mapper.Map<days_of_old>(this);
        }
    }
}
