using SchoolAdministration.Models.Domain.School;
using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.ManualMapper
{
    public static class ClassMappingExtentions
    {

        public static IEnumerable<ClassDTO> MapSchoolClassToClassClassDtos(this IEnumerable<SchoolClass> classes)
        {
            return classes.Select(c => new ClassDTO
            {
                Id = c.Id,
                Name = c.Name,
                Grade = c.Grade,
                SchoolId = c.SchoolId,
                TeacherId = c.TeacherId,
                DepartmentId = c.DepartmentId,
                IsActive = c.IsActive,
                AcademicYear = c.AcademicYear,
                RoomNumber = c.RoomNumber
            });
        }

        public static ClassDTO MapSchoolClassToSchoolClassDto(this SchoolClass schoolClass)
        {
            return new ClassDTO
            {
                Id = schoolClass.Id,
                Name = schoolClass.Name,
                Grade = schoolClass.Grade,
                SchoolId = schoolClass.SchoolId,
                TeacherId = schoolClass.TeacherId,
                DepartmentId = schoolClass.DepartmentId,
                IsActive = schoolClass.IsActive,
                AcademicYear = schoolClass.AcademicYear,
                RoomNumber = schoolClass.RoomNumber
            };
        }

        public static SchoolClass MapClassCreateDtoToSchoolClass(this ClassCreateDTO dto)
        {
            return new SchoolClass
            {
                Name = dto.Name,
                Grade = dto.Grade,
                SchoolId = dto.SchoolId,
                TeacherId = dto.TeacherId,
                DepartmentId = dto.DepartmentId,
                IsActive = dto.IsActive,
                AcademicYear = dto.AcademicYear,
                RoomNumber = dto.RoomNumber,
                //to do : add created by and created date
            };
        }

        public static SchoolClass MapClassUpdateDtoToSchoolClass(this ClassUpdateDTO dto)
        {
            return new SchoolClass
            {
                Id = dto.Id,
                Name = dto.Name,
                Grade = dto.Grade,
                SchoolId = dto.SchoolId,
                TeacherId = dto.TeacherId,
                DepartmentId = dto.DepartmentId,
                IsActive = dto.IsActive,
                AcademicYear = dto.AcademicYear,
                RoomNumber = dto.RoomNumber
                //to do : add updated by and updated date
            };
        }

    }
}
