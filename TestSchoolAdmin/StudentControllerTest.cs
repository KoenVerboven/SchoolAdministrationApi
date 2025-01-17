using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAdministration.Controllers;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace TestSchoolAdmin
{
    public  class StudentControllerTest
    {
        private readonly Mock<IStudentRepository> _mockStudentRepo;
        private readonly Mock<ILogger<StudentController>> _mockILogger;
        private readonly Mock<IMapper> _mockMapper;

        public StudentControllerTest()
        {
            _mockStudentRepo = new Mock<IStudentRepository>(MockBehavior.Default);
            _mockILogger = new Mock<ILogger<StudentController>>(MockBehavior.Default);
            _mockMapper = new Mock<IMapper>(MockBehavior.Default);
        }

        [Fact]
        public async Task GetAllAync_MustBe_OfType_OkObjectResult()
        {
            //arrange
            _mockStudentRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(StudentList());
            var controller = new StudentController(_mockILogger.Object, _mockStudentRepo.Object, _mockMapper.Object);

            //act
            var actionResult = await controller.GetAllStudentsAsync();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }

        private IEnumerable<Student> StudentList()
        {
            IEnumerable<Student> studentList = [
                new Student()
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
                    ParentPhoneNumber = "546",
                    ParentLastname  = null,
                    ParentFirstName = null,
                    Courses = null,
                    StudyPlans = null
                },
                new Student()
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
                    ParentPhoneNumber = "546",
                    ParentLastname  = null,
                    ParentFirstName = null,
                    Courses = null,
                    StudyPlans = null
                },

                ];
            return studentList;
        }
    }
}
