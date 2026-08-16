using SchoolAdministration.Models.Domain.HomeWork;

namespace SchoolAdministrationTests.Data
{
    internal static class HomeWorkMockData
    {
        internal static IEnumerable<HomeWork> HomeWorkList()
        {
            IEnumerable<HomeWork> homeWorkList = [
                new HomeWork()
                {
                   Id = 1,
                   Name= "HomeWork 1",
                   DueDate= DateTime.Now,
                   TeacherId= 1,
                   HomeWorkDetailLines = new HomeWorkDetailLine[]
                   {
                       new()
                       {
                           Id = 1,
                           HomeWorkAssignment = "HomeWork Detail Line 1",
                           HomeWorkId = 1
                       },
                       new()
                       {
                           Id = 2,
                           HomeWorkAssignment = "HomeWork Detail Line 2",
                           HomeWorkId = 1
                       }
                   }
                },
            new HomeWork()
                {
                   Id = 2,
                    Name= "HomeWork 1",
                   DueDate= DateTime.Now,
                   TeacherId= 1,
                   HomeWorkDetailLines = new HomeWorkDetailLine[]
                   {
                       new()
                       {
                           Id = 1,
                           HomeWorkAssignment = "HomeWork Detail Line 1",
                           HomeWorkId = 1
                       },
                       new()
                       {
                           Id = 2,
                           HomeWorkAssignment = "HomeWork Detail Line 2",
                           HomeWorkId = 1
                       }
                   }

                }
                ]; ;
            return homeWorkList;
        }
    }
}
