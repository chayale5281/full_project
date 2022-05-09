using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal;
namespace Dto
{
    public class Days_of_worDto
    {
        public Days_of_worDto()
        { 
        }
        public int iddayw { get; set; }
        public Nullable<int> idwor { get; set; }
        public string dayw { get; set; }
        public Nullable<int> hourstartw { get; set; }
        public Nullable<int> hourendw { get; set; }
        public Nullable<int> confid { get; set; }

        public static Days_of_worDto DalToDto(days_of_wor dw)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<days_of_wor, Days_of_worDto>());
            var mapper = config.CreateMapper();
            return mapper.Map<Days_of_worDto>(dw);
        }
        public days_of_wor DtoToDal()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Days_of_worDto, days_of_wor>());
            var mapper = config.CreateMapper();
            return mapper.Map<days_of_wor>(this);
        }
    }
}
