using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolAdministration.Controllers;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;


namespace TestSchoolAdmin
{
    public class TeacherControllerTest
    {

        private readonly Mock<ITeacherRepository> _mockTeacherRepo;

        public TeacherControllerTest()
        {
            _mockTeacherRepo = new Mock<ITeacherRepository>(MockBehavior.Default);
        }

        [Fact]
        public async Task GetAllAync_MustBe_OfType_OkObjectResult()
        {
            //arrange
            _mockTeacherRepo.Setup(x => x.GetAllAsyn()).ReturnsAsync(TeacherList());
            var controller = new TeacherController(_mockTeacherRepo.Object);

            //act
            var actionResult = await controller.GetAllTeachersAsync();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async Task GetAsynById_teacherClass_must_be_equal_to_teacherResult()
        {
            //arrange
            var expected = new Teacher()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999,10,10),
                StreetAndNumber = "Grotelaan 45",
                Zipcode = 2000,
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
            };
            _mockTeacherRepo.Setup(x => x.GetAsynById(1)).ReturnsAsync(expected);
            var controller = new TeacherController(_mockTeacherRepo.Object);

            //act
            var actionResult = await  controller.GetTeacherById(1);

            //assert
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as Teacher;
            Assert.NotNull(model);

            var actual = model;
            Assert.Equal(expected, actual);

        }

        private IEnumerable<Teacher> TeacherList()
        {
            IEnumerable<Teacher> teacherList = [
                new Teacher()
                {
                    Id = 1,
                    FirstName = "Koen",
                    LastName = "Verboven",
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    StreetAndNumber = "Grotelaan 45",
                    Zipcode = 2000,
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
                    StreetAndNumber = "Kerkstraat 454",
                    Zipcode = 2000,
                    Gender = 1,
                    Email="mark@test.be",
                    Phone = "44994989",
                    HireDate = DateTime.Now,
                    LeaveDate = null,
                    MaritalStatusId = 1,
                },

                ];
            return teacherList;
        }
    }
}
