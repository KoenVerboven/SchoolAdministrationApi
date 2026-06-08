using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAdministration.AutoMapper;
using SchoolAdministration.Controllers;
using SchoolAdministration.Models.Domain.HomeWork;
using SchoolAdministration.Models.Domain.Student;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;

namespace TestSchoolAdmin;

public class HomeWorkControllerTest
{
    private readonly Mock<IHomeWorkRepository>? _mockHomeWorkRepo;
    private readonly Mock<ILogger<HomeWorkController>> _mockILogger;
    private readonly MapperConfiguration? _mapperConfiguration;


    public HomeWorkControllerTest()
    {
        _mockHomeWorkRepo = new Mock<IHomeWorkRepository>(MockBehavior.Default);
        _mockILogger = new Mock<ILogger<HomeWorkController>>(MockBehavior.Default);

        var myProfile = new MappingConfig();
        _mapperConfiguration = new MapperConfiguration(
            cfg => cfg.AddProfile(myProfile), new LoggerFactory()
        );
    }


    [Fact]
    public async Task GetAllAync_ShallReturnTypeOK_ForCourseListContainItems()
    {
        //arrange
        var mapper = new Mapper(_mapperConfiguration);
        _mockHomeWorkRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(HomeWorkList());
        var controller = new HomeWorkController(_mockHomeWorkRepo.Object, _mockILogger.Object, mapper);

        //act
        var actionResult = await controller.GetAllHomeWorks();
        //assert
        Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.NotNull(actionResult);
    }

    [Fact]
    public async Task GetAsynById_ShallReturnHomeWorkWithId_ForExistingHomeWorkWithId()
    {
        //arrange
        var homeWork = new HomeWork()
        {
            Id = 1,
            Name = "HomeWork 1",
            DueDate = DateTime.Now,
            TeacherId = 1,
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

        };

        var homeWorkDTO = new HomeWorkDTO
        {
            Id = homeWork.Id,
            Name = homeWork.Name,
            DueDate = homeWork.DueDate,
            TeacherId= homeWork.TeacherId,
            HomeWorkDetailLines = homeWork.HomeWorkDetailLines
        };

        var mapper = new Mapper(_mapperConfiguration);
        _mockHomeWorkRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(homeWork);
        var controller = new HomeWorkController(_mockHomeWorkRepo.Object, _mockILogger.Object, mapper);

        //act
        var actionResult = await controller.GetHomeworkById(1);
        //assert
        var okObjectResult = actionResult.Result as OkObjectResult;
        Assert.NotNull(okObjectResult);

        var actual = okObjectResult.Value as HomeWorkDTO;
        Assert.NotNull(actual);
        Assert.Equal(homeWorkDTO.Id, actual.Id);
        Assert.Equal(homeWorkDTO.Name, actual.Name);
        Assert.Equal(homeWorkDTO.DueDate, actual.DueDate);
        Assert.Equal(homeWorkDTO.TeacherId, actual.TeacherId);
        Assert.Equivalent(homeWorkDTO, actual);
    }

    private IEnumerable<HomeWork> HomeWorkList()
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
