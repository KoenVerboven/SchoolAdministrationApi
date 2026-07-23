using SchoolAdministration.Models.Domain.Teacher;
using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.ManualMapper
{
    public static class TeacherMappingExtensions
    {
        public static IEnumerable<TeacherDTO> MapTeachersToTeacherDtos(this IEnumerable<Teacher> teachers)
        {
            List<TeacherDTO> teachersDTO = new();
            foreach (var teacher in teachers)
            {
                teachersDTO.Add(new TeacherDTO      
                {
                    Id = teacher.Id,
                    LastName = teacher.LastName,
                    FirstName = teacher.FirstName,
                    Gender = teacher.Gender,
                    Email = teacher.Email,
                    DateOfBirth = teacher.DateOfBirth,
                    Phone = teacher.Phone,
                    HireDate = teacher.HireDate,
                    MaritalStatusId = teacher.MaritalStatusId,
                    TeacherAddresses = teacher.TeacherAddresses
                });
            }
            return teachersDTO;
        }


        public static TeacherDTO MapTeacherToTeacherDto(this Teacher teacher)
        {
            return new TeacherDTO
            {
                Id = teacher.Id,
                LastName = teacher.LastName,
                FirstName = teacher.FirstName,
                Email = teacher.Email,
                Phone = teacher.Phone,
                DateOfBirth = teacher.DateOfBirth,
                HireDate = teacher.HireDate,
                MaritalStatusId = teacher.MaritalStatusId,
                TeacherAddresses = teacher.TeacherAddresses,
                TeacherPresences = teacher.TeacherPresences,
                SchoolClasses = teacher.SchoolClasses

                //todo : map other properties as needed
            };
        }


        public static Teacher MapTeacherCreateDtoToTeacher(this TeacherCreateDTO dto)
        {
            return new Teacher
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Email = dto.Email,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth,
                HireDate = dto.HireDate,
                MaritalStatusId = dto.MaritalStatusId,
                CreatedBy = dto.CreatedBy,
                CreatedDate = DateTime.Now
            };
        }

        public static Teacher MapTeacherUpdateDtoToTeacher(this TeacherUpdateDTO dto)
        {
            return new Teacher
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Email = dto.Email,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth,
                HireDate = dto.HireDate,
                MaritalStatusId = dto.MaritalStatusId,
                UpdatedBy = dto.UpdatedBy,
                UpdateDate = DateTime.Now
            };
        }
    }
}

  
