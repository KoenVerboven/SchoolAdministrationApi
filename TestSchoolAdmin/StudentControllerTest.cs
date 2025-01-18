using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAdministration.AutoMapper;
using SchoolAdministration.Controllers;
using SchoolAdministration.Dtos;
using SchoolAdministration.Models;
using SchoolAdministration.Repositories.Interfaces;

namespace TestSchoolAdmin
{
    public  class StudentControllerTest
    {
        private readonly Mock<IStudentRepository> _mockStudentRepo;
        private readonly Mock<ILogger<StudentController>> _mockILogger;

        public StudentControllerTest()
        {
            _mockStudentRepo = new Mock<IStudentRepository>(MockBehavior.Default);
            _mockILogger = new Mock<ILogger<StudentController>>(MockBehavior.Default);
        }

        [Fact]
        public async Task GetAllAync_MustBe_OfType_OkObjectResult()
        {
            //arrange
            var myProfile = new MappingConfig();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _mockStudentRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(StudentList());
            var controller = new StudentController(_mockILogger.Object, _mockStudentRepo.Object, mapper);

            //act
            var actionResult = await controller.GetAllStudentsAsync();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }


        [Fact]
        public async Task GetAsynById_studentClass_must_be_equal_to_studentResult()
        {
            //arrange
            var student = new Student()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                StreetAndNumber = "Grotelaan 45",
                Zipcode = 2000,
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                ParentPhoneNumber = "546",
                ParentLastname = null,
                ParentFirstName = null,
                Courses = null,
                StudyPlans = null
            };
           
            var studentsDTO = new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                StreetAndNumber = student.StreetAndNumber,
                Zipcode = student.Zipcode,
                Gender = student.Gender,
                Email = student.Email,
                Phone = student.Phone,
                ParentPhoneNumber = student.ParentPhoneNumber,
                ParentLastname = student.ParentLastname,
                ParentFirstName = student.ParentFirstName
            };
           
            var myProfile = new MappingConfig();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _mockStudentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(student);
            var controller = new StudentController(_mockILogger.Object, _mockStudentRepo.Object, mapper);

            //act
            var actionResult = await controller.GetStudentById(1);

            //assert
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var actual = okObjectResult.Value as StudentDTO;
            Assert.NotNull(actual);
            Assert.Equal(studentsDTO.Id, actual.Id);
            Assert.Equal(studentsDTO.FirstName, actual.FirstName);
            Assert.Equal(studentsDTO.LastName, actual.LastName);
            Assert.Equivalent(studentsDTO, actual);
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
                }
                ];
            return studentList;
        }
    }
}
