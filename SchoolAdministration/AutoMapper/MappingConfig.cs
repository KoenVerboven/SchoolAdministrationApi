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
            CreateMap<Student, StudentUpdateDTO>().ReverseMap();

            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<Teacher, TeacherCreateDTO>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDTO>().ReverseMap();

            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Course, CourseCreateDTO>().ReverseMap();
            CreateMap<Course, CourseUpdateDTO>().ReverseMap();
        }
    }
}
