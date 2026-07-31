using SchoolAdministration.Models.Domain.School;
using SchoolAdministration.Models.DTO;

namespace SchoolAdministration.ManualMapper
{
    public static class SchoolMappingExtentions
    {
        public static IEnumerable<SchoolDTO> MapSchoolsToSchoolDtos(this IEnumerable<School> schools)
        {
            return schools.Select(school => new SchoolDTO
            {
                Id = school.Id,
                Name = school.Name,
                StreetAndNumber = school.StreetAndNumber,
                ZipCode = school.ZipCode,
                ContactPhone = school.ContactPhone,
                ContactEmail = school.ContactEmail,
                Website = school.Website,
                LogoUrl = school.LogoUrl,
                Description =   school.Description,
                SchoolType = school.SchoolType,
                NumberOfStudents = school.NumberOfStudents,
                NumberOfTeachers = school.NumberOfTeachers,
            });
        }

        public static SchoolDTO  MapSchoolToSchoolDto(this School school)
        {
            return new SchoolDTO
            {   
                Id = school.Id,
                Name = school.Name,
                StreetAndNumber = school.StreetAndNumber,
                ZipCode = school.ZipCode,
                ContactPhone = school.ContactPhone,
                ContactEmail = school.ContactEmail,
                Website = school.Website,
                LogoUrl = school.LogoUrl,
                Description = school.Description,
                SchoolType = school.SchoolType,
                NumberOfStudents = school.NumberOfStudents,
                NumberOfTeachers = school.NumberOfTeachers,
                Facilities = school.Facilities,
                SocialMedia = school.SocialMedia
            };
        }

        public static School MapSchoolCreateDtoToSchool(this SchoolCreateDTO schoolCreatedto)
        {
            return new School   
            {
                Name =  schoolCreatedto.Name,
                StreetAndNumber = schoolCreatedto.StreetAndNumber,
                ZipCode = schoolCreatedto.ZipCode,
                CountryId = schoolCreatedto.CountryId,
                ContactPhone = schoolCreatedto.ContactPhone,
                ContactEmail = schoolCreatedto.ContactEmail,
                Website = schoolCreatedto.Website,
                LogoUrl = schoolCreatedto.LogoUrl,
                Description = schoolCreatedto.Description,
                SchoolType = schoolCreatedto.SchoolType,
                NumberOfStudents = schoolCreatedto.NumberOfStudents,
                NumberOfTeachers = schoolCreatedto.NumberOfTeachers,
                EstablishedYear = schoolCreatedto.EstablishedYear,
                Facilities = schoolCreatedto.Facilities,
                SocialMedia = schoolCreatedto.SocialMedia,
                CreatedBy = schoolCreatedto.CreatedBy,
                CreatedAt = DateTime.Now
            };
        }

        public static School MapSchoolUpdateDtoToSchool(this SchoolUpdateDTO dto)
        {
            return new School
            {
                Name = dto.Name,
                StreetAndNumber = dto.StreetAndNumber,
                ZipCode = dto.ZipCode,
                CountryId = dto.CountryId,
                ContactPhone = dto.ContactPhone,
                ContactEmail = dto.ContactEmail,
                Website = dto.Website,
                LogoUrl = dto.LogoUrl,
                Description = dto.Description,
                CreatedBy = dto.CreatedBy,  // nok nakijken
                UpdatedBy = dto.UpdatedBy, 
                //UpdateDate = DateTime.Now
            };
        }
    }
}
