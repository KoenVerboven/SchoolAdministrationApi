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

            CreateMap<Exam, ExamDTO>().ReverseMap();
            CreateMap<Exam, ExamCreateDTO>().ReverseMap();
            CreateMap<Exam, ExamUpdateDTO>().ReverseMap();

            CreateMap<School, SchoolDTO>().ReverseMap();
            CreateMap<School, SchoolCreateDTO>().ReverseMap();
       
            CreateMap<SchoolDepartment, DepartmentDTO>().ReverseMap();
            CreateMap<SchoolDepartment, DepartmentCreateDTO>().ReverseMap();

            CreateMap<SchoolClass, ClassDTO>().ReverseMap();
            CreateMap<SchoolClass, ClassCreateDTO>().ReverseMap();

            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
