using AutoMapper;
using RodjendaniProjekat.APIRecords;
using RodjendaniProjekat.Models;
using System.Runtime;

namespace RodjendaniProjekat.Mapper
{
    public class BirthdayMapperProfile : Profile 
    {
        public BirthdayMapperProfile()
        {
            CreateMap<BirthdayDTO, Birthday>();
            CreateMap<Birthday, BirthdayResponseDto>(); 
        }
    }
}
