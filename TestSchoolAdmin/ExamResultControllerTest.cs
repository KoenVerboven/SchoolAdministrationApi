using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAdministration.AutoMapper;
using SchoolAdministration.Controllers;
using SchoolAdministration.Models.Domain.Exam;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Repositories.Interfaces;

namespace SchoolAdministrationTests
{
    public class ExamResultControllerTest
    {
        private readonly Mock<IExamResultRepository>? _mockExamResultRepo;
        private readonly Mock<ILogger<ExamResultController>> _mockILogger;
        private readonly MapperConfiguration? _mapperConfiguration;

        public ExamResultControllerTest()
        {
            _mockExamResultRepo = new Mock<IExamResultRepository>(MockBehavior.Default);
            _mockILogger = new Mock<ILogger<ExamResultController>>(MockBehavior.Default);

            var myProfile = new MappingConfig();
            _mapperConfiguration = new MapperConfiguration(
                cfg => cfg.AddProfile(myProfile), new LoggerFactory()
            );
        }


        [Fact]
        public async Task GetAllAync_ShallReturnTypeOK_ForExamListContainItems()
        {
            //arrange
            var mapper = new Mapper(_mapperConfiguration);
            _mockExamResultRepo.Setup(x => x.GetAllExamResultsAsync()).ReturnsAsync(ExamResultList());
            var controller = new ExamResultController(_mockExamResultRepo.Object, _mockILogger.Object, mapper);

            //act
            var actionResult = await controller.GetAllExamResultAsync();
            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }


        private IEnumerable<ExamResult> ExamResultList()
        {
            IEnumerable<ExamResult> examResultList = [
                new ExamResult()
                {
                    Id = 1,
                    StudentId = 1,
                    CourseId = 1,
                    QAExamId = 1,
                    ExamenResultScore = 10,
                    ExamenResultComment = "VeryGood",
                    CheckedByTeacherId = 1,
                    Student = new Student()
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
                    }
                },
                new ExamResult()
                {
                    Id = 2,
                    StudentId = 2,
                    CourseId = 2,
                    QAExamId = 2,
                    ExamenResultScore = 8,
                    ExamenResultComment = "Good",
                    CheckedByTeacherId = 2,
                    Student = new Student()
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
                }];

            return examResultList;
        }
    }
}
