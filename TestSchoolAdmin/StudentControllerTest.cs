using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAdministration.Controllers;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministration.Models.Domain.Student;


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
        public async Task GetAllAync_ShallReturnTypeOK_ForStudentListContainItems()
        {
            //arrange
            _mockStudentRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(StudentList());
            var controller = new StudentController(_mockStudentRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.GetAllStudentsAsync();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }


        [Fact]
        public async Task GetAllAync_ShallReturnItemsCount_ForStudentListContainItems()
        {
            //arrange
            _mockStudentRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(StudentList());
            var controller = new StudentController(_mockStudentRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.GetAllStudentsAsync();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);

            var okObjectResult = actionResult.Result as OkObjectResult;
            var actual = okObjectResult!.Value as IEnumerable<StudentDTO>;
            var count = actual!.Count();
            Assert.Equal(2, count);
        }


        [Fact]
        public async Task GetAsynById_ShallReturnStudentWithId_ForExistingStudentWithId() 
        {
            //arrange
            var student = new Student()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                Picture = null,
                Courses = null,
                StudyPlans = null,
                StudentAddresses = null,
                StudentClassRegistrations = null,
                StudentPresences = null,
                Parents = null,
                Invoices = null,
                HomeWorks = null,
                StudentImage = null,
                Payments = null,
                ExamResults = null

            };
           
            var studentsDTO = new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Email = student.Email,
                Phone = student.Phone,
                Picture = student.Picture,
                StudyPlans = student.StudyPlans,
                StudentAddresses = student.StudentAddresses,
                StudentClassRegistrations = student.StudentClassRegistrations,
                StudentPresences = student.StudentPresences,
                Parents = student.Parents,
                Invoices = student.Invoices,
                HomeWorks = student.HomeWorks,
                Payments = student.Payments,
                ExamResults = student.ExamResults
            };
           
            _mockStudentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(student);
            var controller = new StudentController(_mockStudentRepo.Object, _mockILogger.Object);

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

        [Fact]
        public async Task GetAsynById_ShallReturnNotFoundResult_WhenStudentNotFound()
        {
            //arrange
            var student = new Student()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                Courses = null,
                StudyPlans = null
            };

            _mockStudentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(student);
            var controller = new StudentController(_mockStudentRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.GetStudentById(99);

            //assert
            var notFoundObjectResult = actionResult.Result as NotFoundResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public async Task GetAsynById_ShallReturnBadRequest_WhenStudentIdEqualsZero()
        {
            //arrange
            var student = new Student()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                Courses = null,
                StudyPlans = null
            };

            _mockStudentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(student);
            var controller = new StudentController(_mockStudentRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.GetStudentById(0);

            //assert
            Assert.IsType<BadRequestResult>(actionResult.Result);
        }

        [Fact]
        public async Task CreateStudent_AddStudentCorrectly_WhenNewStudentIsAdded()
        {
            //arrange
            var student = new Student()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                Courses = null,
                StudyPlans = null
            };

            var newStudent = new StudentCreateDTO()
            {
                FirstName = "Maria",
                LastName = "Poels",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "maria@test.be",
                Phone = "4483892639",
            };

            _mockStudentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(student);
            var controller = new StudentController(_mockStudentRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.CreateStudent(newStudent);

            //assert
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }



        [Fact]
        public async Task UpdateStudentAsync_UpdateStudentCorrectly_WhenIdIsEqualToDtudentUpdateDTOIdAndModelStateIsValid()
        {
            //arrange
            var student = new Student()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                Courses = null,
                StudyPlans = null
            };

            var updatedStudent = new StudentUpdateDTO()
            {
                Id = 1,
                FirstName = "Pieter",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
            };

            _mockStudentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(student);
            var controller = new StudentController(_mockStudentRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.UpdateStudentAsync(1, updatedStudent);

            //assert
            var okObjectResult = actionResult.Result as CreatedAtActionResult;
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            var actual = okObjectResult!.Value as Student;
            Assert.NotNull(actual);
            Assert.Equal(updatedStudent.Id, actual.Id);
            Assert.Equal(updatedStudent.FirstName, actual.FirstName);
            Assert.Equivalent(updatedStudent,actual);
        }

        [Fact]
        public async Task DeleteStudentById_DeleteCorrectly_WhenValidIdIsGiven()
        {
            //arrange
            var student = new Student()
            {
                Id = 1,
                FirstName = "Koen",
                LastName = "Verboven",
                DateOfBirth = new DateTime(1999, 10, 10),
                Gender = 1,
                Email = "koen@test.be",
                Phone = "448389639",
                Courses = null,
                StudyPlans = null
            };

            _mockStudentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(student);
            var controller = new StudentController(_mockStudentRepo.Object, _mockILogger.Object);

            //act
            var actionResult = await controller.DeleteStudentById(1);

            //assert
            var okObjectResult = actionResult as NoContentResult;
            Assert.IsType<NoContentResult>(actionResult);
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
                    Gender = 1,
                    Email="koen@test.be",
                    Phone = "448389639",
                    Courses = null,
                    StudyPlans = null
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Mark",
                    LastName = "Peeters",
                    DateOfBirth = DateTime.Now.AddYears(-34),
                    Gender = 1,
                    Email="mark@test.be",
                    Phone = "44994989",
                    Courses = null,
                    StudyPlans = null
                }
                ];
            return studentList;
        }

        

    }
}
