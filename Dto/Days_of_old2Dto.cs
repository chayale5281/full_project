using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal;

namespace Dto
{
    public class Days_of_old2Dto
    {
        public Days_of_old2Dto()
        {

        }
        public int iddayo { get; set; }
        public Nullable<int> idold { get; set; }
        public Nullable<bool> isSunday { get; set; }
        public Nullable<bool> isManday { get; set; }
        public Nullable<bool> isTuthday { get; set; }
        public Nullable<bool> isWenthday { get; set; }
        public Nullable<bool> isThursday { get; set; }
        public Nullable<bool> isFriday { get; set; }
        public Nullable<bool> isShabbat { get; set; }
        public Nullable<int> hourstarto { get; set; }
        public Nullable<int> hourendo { get; set; }
        public Nullable<int> conoID { get; set; }
        public Nullable<bool> isavliable { get; set; }



        public static Days_of_old2Dto DalToDto(days_of_old2 d)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<days_of_old2, Days_of_old2Dto>());
            var mapper = config.CreateMapper();
            return mapper.Map<Days_of_old2Dto>(d);
        }
        public days_of_old2 DtoToDal()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Days_of_old2Dto, days_of_old2>());
            var mapper = config.CreateMapper();
            return mapper.Map<days_of_old2>(this);
        }
    }
}


    
    

