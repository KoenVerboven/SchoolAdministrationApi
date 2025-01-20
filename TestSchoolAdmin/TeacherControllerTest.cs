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
    public class TeacherControllerTest
    {

        private readonly Mock<ITeacherRepository> _mockTeacherRepo;
        private readonly Mock<ILogger<TeacherController>> _mockILogger;

        public TeacherControllerTest()
        {
            _mockTeacherRepo = new Mock<ITeacherRepository>(MockBehavior.Default);
            _mockILogger = new Mock<ILogger<TeacherController>>(MockBehavior.Default);
        }

        [Fact]
        public async Task GetAllAync_MustBe_OfType_OkObjectResult()
        {
            //arrange
            var myProfile = new MappingConfig();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _mockTeacherRepo.Setup(x => x.GetAllAsyn()).ReturnsAsync(TeacherList());
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object, mapper);

            //act
            var actionResult = await controller.GetAllTeachersAsync();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async Task GetAllAync_CountMustBe_3()
        {
            //arrange
            var myProfile = new MappingConfig();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            _mockTeacherRepo.Setup(x => x.GetAllAsyn()).ReturnsAsync(TeacherList());
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object, mapper);

            //act
            var actionResult = await controller.GetAllTeachersAsync();
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            var actual = okObjectResult.Value as IEnumerable<TeacherDTO>;

            //assert
            Assert.Equal(3, actual.Count());
        }



        [Fact]
        public async Task GetAsynById_teacherClass_must_be_equal_to_teacherResult()
        {
            //arrange
            var myProfile = new MappingConfig();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);
            var teacher = new Teacher()
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
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
            };

            var teacherDTO = new TeacherDTO
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                DateOfBirth = teacher.DateOfBirth,
                StreetAndNumber = teacher.StreetAndNumber,
                Zipcode = teacher.Zipcode,
                Gender = teacher.Gender,
                Email = teacher.Email,
                Phone = teacher.Phone,
                HireDate = teacher.HireDate,
                LeaveDate = teacher.LeaveDate,
                MaritalStatusId = teacher.MaritalStatusId,
            };


            _mockTeacherRepo.Setup(x => x.GetAsynById(1)).ReturnsAsync(teacher);
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object, mapper);

            //act
            var actionResult = await controller.GetTeacherById(1);

            //assert
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as TeacherDTO;
            Assert.NotNull(model);

            var actual = model;
            Assert.Equal(teacherDTO.LastName, actual.LastName);

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
                new Teacher()
                {
                    Id = 2,
                    FirstName = "Linda",
                    LastName = "Versmissen",
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    StreetAndNumber = "BerkenStraat 4",
                    Zipcode = 2000,
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
