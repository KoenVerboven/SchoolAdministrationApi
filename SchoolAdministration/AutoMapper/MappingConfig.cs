using AutoMapper;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;

namespace SchoolAdministration.AutoMapper
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, StudentCreateDTO>().ReverseMap();
            CreateMap<Student,StudentUpdateDTO>().ReverseMap();
        }
    }
}
