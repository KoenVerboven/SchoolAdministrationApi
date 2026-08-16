using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAdministration.AutoMapper;
using SchoolAdministration.Controllers;
using SchoolAdministration.Repositories.Interfaces;
using SchoolAdministrationTests.Data;

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
            _mockExamResultRepo.Setup(x => x.GetAllExamResultsAsync()).ReturnsAsync(ExamResultMockData.ExamResultList());
            var controller = new ExamResultController(_mockExamResultRepo.Object, _mockILogger.Object, mapper);

            //act
            var actionResult = await controller.GetAllExamResultAsync();
            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }
    }
}
