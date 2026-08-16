using SchoolAdministration.Models.Domain.Teacher;

namespace SchoolAdministrationTests.Data
{
    internal static class TeacherData
    {
        internal static IEnumerable<Teacher> TeacherList()
        {
            IEnumerable<Teacher> teacherList = [
                new Teacher()
                {
                    Id = 1,
                    FirstName = "Koen",
                    LastName = "Verboven",
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    Gender = 1,
                    Email="koen@test.be",
                    Phone = "448389639",
                    HireDate = DateTime.Now,
                    LeaveDate = null,
                    MaritalStatusId = 1,
                },
                new Teacher()
                {
                    Id = 2,
                    FirstName = "Mark",
                    LastName = "Peeters",
                    DateOfBirth = DateTime.Now.AddYears(-34),
                    Gender = 1,
                    Email="mark@test.be",
                    Phone = "44994989",
                    HireDate = DateTime.Now,
                    LeaveDate = null,
                    MaritalStatusId = 1,
                },
                new Teacher()
                {
                    Id = 2,
                    FirstName = "Linda",
                    LastName = "Versmissen",
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    Gender = 1,
                    Email="linda@test.be",
                    Phone = "44994419",
                    HireDate = DateTime.Now,
                    LeaveDate = null,
                    MaritalStatusId = 1,
                },

                ];
            return teacherList;
        }
    }
}
