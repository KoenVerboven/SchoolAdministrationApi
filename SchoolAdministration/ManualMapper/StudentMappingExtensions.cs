using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.DTO;   

namespace SchoolAdministration.ManualMapper
{
    public static class StudentMappingExtensions
    {
        public static IEnumerable<StudentDTO> MapStudentsToStudentDtos(this IEnumerable<Student> students)
        {
            List<StudentDTO> studentsDTO = new();
            foreach (var student in students)
            {
                studentsDTO.Add(new StudentDTO
                {
                    Id = student.Id,
                    LastName = student.LastName,
                    FirstName = student.FirstName,
                    Gender = student.Gender,
                    Email = student.Email,
                    DateOfBirth = student.DateOfBirth,
                    Phone = student.Phone,
                    RegistrationDate = student.RegistrationDate,
                    StudentAddresses = student.StudentAddresses,
                });
            }
            return studentsDTO;
        }

        public static StudentDTO MapStudentToStudentDto(this Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                LastName = student.LastName,
                Gender = student.Gender,
                FirstName = student.FirstName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Phone = student.Phone,
                Age = student.Age,
                RegistrationDate = student.RegistrationDate,
                StudentAddresses = student.StudentAddresses

                //todo : map other properties as needed
            };
        }

        public static Student MapStudentDtoCreateToStudent(this StudentCreateDTO dto)
        {
            return new Student
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Email = dto.Email,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth,
                CreatedBy = dto.CreatedBy,
                CreatedDate = DateTime.Now,
                RegistrationDate = DateTime.Now
            };
        }

        public static Student MapStudentDtoUpdateToStudent(this StudentUpdateDTO dto)
        {
            return new Student
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Email = dto.Email,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth,
                UpdatedBy = dto.UpdatedBy,
            };
        }


    }
}



