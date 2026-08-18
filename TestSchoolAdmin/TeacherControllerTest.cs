using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAdministration.Controllers;
using SchoolAdministration.Models.Domain.Teacher;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministrationTests.Data;


namespace SchoolAdministrationTests
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
        public async Task GetAllAync_ShallReturnTypeOK_ForTeacherListContainItems()
        {
            //arrange
            _mockTeacherRepo.Setup(x => x.GetAllAsyn()).ReturnsAsync(TeacherData.TeacherList());
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.GetAllTeachersAsync();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }

        [Fact]
        public async Task GetAllAync_ShallReturnCount_ForTeacherListContainItems()
        {
            //arrange
            _mockTeacherRepo.Setup(x => x.GetAllAsyn()).ReturnsAsync(TeacherData.TeacherList());
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.GetAllTeachersAsync();
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            var actual = okObjectResult.Value as IEnumerable<TeacherDTO>;

            //assert
            Assert.Equal(3, actual!.Count());
        }



        [Fact]
        public async Task GetAsynById_ShallReturnTeacherWithId_ForExistingTeacherWithId()
        {
            //arrange
            var teacher = new Teacher()
            {
                Id = 13,
                FirstName = "Piet1",
                LastName = "Gevers",
                DateOfBirth = new DateTime(2000, 06, 15),
                Gender = 1,
                Email = "Piet1@test.be",
                Phone = "448389639",
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
                TeacherAddresses = null,
                TeacherPresences = null,
                SchoolClasses = null
            };

            var teacherDTO = new TeacherDTO
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                DateOfBirth = teacher.DateOfBirth,
                Gender = teacher.Gender,
                Email = teacher.Email,
                Phone = teacher.Phone,
                HireDate = teacher.HireDate,
                LeaveDate = teacher.LeaveDate,
                MaritalStatusId = teacher.MaritalStatusId,
                TeacherAddresses = teacher.TeacherAddresses,
                TeacherPresences = teacher.TeacherPresences,
                SchoolClasses = teacher.SchoolClasses
            };

            _mockTeacherRepo.Setup(x => x.GetAsynById(13)).ReturnsAsync(teacher);
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.GetTeacherById(13);

            //assert
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var model = okObjectResult.Value as TeacherDTO;
            Assert.NotNull(model);

            var actual = model;
            Assert.Equal(teacherDTO.LastName, actual.LastName);
            Assert.Equivalent(teacherDTO, actual);
        }


        [Fact]
        public async Task GetAsynById_ShallReturnNotFoundResult_WhenTeacherNotFound()
        {
            //arrange
            var teacher = new Teacher()
            {
                Id = 13,
                FirstName = "Piet1",
                LastName = "Gevers",
                DateOfBirth = new DateTime(2000, 06, 15),
                Gender = 1,
                Email = "Piet1@test.be",
                Phone = "448389639",
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
                TeacherAddresses = null,
                TeacherPresences = null,
                SchoolClasses = null
            };

            _mockTeacherRepo.Setup(x => x.GetAsynById(13)).ReturnsAsync(teacher);
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.GetTeacherById(99);

            //assert
            var notFoundObjectResult = actionResult.Result as NotFoundResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public async Task GetAsynById_ShallReturnBadRequest_WhenTeacherIdEqualsZero()
        {
            //arrange
            var teacher = new Teacher()
            {
                Id = 13,
                FirstName = "Piet1",
                LastName = "Gevers",
                DateOfBirth = new DateTime(2000, 06, 15),
                Gender = 1,
                Email = "Piet1@test.be",
                Phone = "448389639",
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
                TeacherAddresses = null,
                TeacherPresences = null,
                SchoolClasses = null
            };

            _mockTeacherRepo.Setup(x => x.GetAsynById(1)).ReturnsAsync(teacher);
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object);
                        
            //act
            var actionResult = await controller.GetTeacherById(0);

            //assert
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Fact]
        public async Task CreateTeacher_AddTeacherCorrectly_WhenNewTeacherIsAdded()
        {
            //arrange
            var teacher = new Teacher()
            {
                Id = 13,
                FirstName = "Piet1",
                LastName = "Gevers",
                DateOfBirth = new DateTime(2000, 06, 15),
                Gender = 1,
                Email = "Piet1@test.be",
                Phone = "448389639",
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
                TeacherAddresses = null,
                TeacherPresences = null,
                SchoolClasses = null
            };

            var newTeacher = new TeacherCreateDTO()
            {
                FirstName = "Edmond",
                LastName = "Poels",
                DateOfBirth = new DateTime(2000, 06, 15),
                Gender = 1,
                Email = "Edmond@test.be",
                Phone = "44837881",
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
            };

            _mockTeacherRepo.Setup(x => x.GetAsynById(13)).ReturnsAsync(teacher);
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.CreateTeacher(newTeacher);

            //assert
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }

        [Fact]
        public async Task UpdateTeacherAsync_UpdateTeacherCorrectly_WhenIdIsEqualToTeacherUpdateDTOIdAndModelStateIsValid()
        {
            //arrange
            var teacher = new Teacher()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
                TeacherAddresses = null,
                TeacherPresences = null,
                SchoolClasses = null
            };

            var updatedTeacher = new TeacherUpdateDTO()
            {
                Id = 1,
                FirstName = "Pieter",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                HireDate = new DateTime(2020, 10, 10),
                LeaveDate = null,
                MaritalStatusId = 1,
            };

            _mockTeacherRepo.Setup(x => x.GetAsynById(1)).ReturnsAsync(teacher);
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.UpdateTeacherAsync(1, updatedTeacher);

            //assert
            var okObjectResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            var actual = okObjectResult!.Value as Teacher;
            Assert.NotNull(actual);
            Assert.Equal(updatedTeacher.Id, actual.Id);
            Assert.Equal(updatedTeacher.FirstName, actual.FirstName);
            Assert.Equivalent(updatedTeacher, actual);
        }

        [Fact]
        public async Task DeleteTeacherById_DeleteCorrectly_WhenValidIdIsGiven()
        {
            //arrange
            var teacher = new Teacher()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
            };

            _mockTeacherRepo.Setup(x => x.GetAsynById(1)).ReturnsAsync(teacher);
            var controller = new TeacherController(_mockTeacherRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.DeleteTeacherById(1);

            //assert
            var okObjectResult = actionResult as NoContentResult;
            Assert.IsType<NoContentResult>(actionResult);
        }

    }
}
