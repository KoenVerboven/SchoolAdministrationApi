using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SchoolAdministration.Controllers;
using SchoolAdministration.Models.Domain.Course;
using SchoolAdministration.Models.DTO;
using SchoolAdministration.Repositories.Interfaces;

namespace TestSchoolAdmin;


public class CourseControllerTests
{
    private readonly Mock<ICourseRepository>? _mockCourseRepo;
    private readonly Mock<ILogger<CourseController>> _mockILogger;
         
    public CourseControllerTests()
    {
        _mockCourseRepo = new Mock<ICourseRepository>(MockBehavior.Default);
       _mockILogger = new Mock<ILogger<CourseController>>(MockBehavior.Default);
    }


    [Fact]
    public async Task GetAllAync_ShallReturnTypeOK_ForCourseListContainItems()
    {
        //arrange
        _mockCourseRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(CourseList());
        var controller = new CourseController(_mockCourseRepo.Object, _mockILogger.Object);                                                                                                                     

        //act
        var actionResult = await controller.GetAllCourses();
        //assert
        Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.NotNull(actionResult);
    }

    [Fact]
    public async Task GetAsynById_ShallReturnCourseWithId_ForExistingCourseWithId()
    {
        //arrange
        var course = new Course()
        {
            Id = 1,
            CourseName = "Electronica A2",
            CourseCode = "E2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now,
            CoursePrice = 10.99M,
            Students = []
        };

        var courseDTO = new CourseDTO
        {
            Id = course.Id,
            CourseName = course.CourseName,
            CourseCode = course.CourseCode,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
            CoursePrice = course.CoursePrice,
            Students = []
        };

        _mockCourseRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(course);
        var controller = new CourseController(_mockCourseRepo.Object, _mockILogger.Object);

        //act
        var actionResult = await controller.GetCourseById(1);
        //assert
        var okObjectResult = actionResult.Result as OkObjectResult;
        Assert.NotNull(okObjectResult);

        var actual = okObjectResult.Value as CourseDTO;
        Assert.NotNull(actual);
        Assert.Equal(courseDTO.Id, actual.Id);
        Assert.Equal(courseDTO.CourseName, actual.CourseName);
        Assert.Equal(courseDTO.CourseCode, actual.CourseCode);
        Assert.Equal(courseDTO.StartDate, actual.StartDate);
        Assert.Equal(courseDTO.EndDate, actual.EndDate);
        Assert.Equal(courseDTO.CoursePrice, actual.CoursePrice);
        Assert.Equivalent(courseDTO, actual);
    }

    [Fact]
    public async Task CreateCourse_AddCourseCorrectly_WhenNewCourseIsAdded()
    {
        //arrange
        var course = new CourseCreateDTO()
        {
            CourseName = "Mathematics M2",
            CourseCode = "M2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now,
            CoursePrice = 15.99M
        };

        var courseCreateDTO = new CourseCreateDTO() 
        {
            CourseName = "Mathematics M2",
            CourseCode = "M2",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now,
            CoursePrice = 15.99M
        };

        var controller = new CourseController(_mockCourseRepo.Object, _mockILogger.Object);

        //act
        var actionResult = await controller.CreateCourse(courseCreateDTO);

        //assert
        Assert.IsType<CreatedAtActionResult>(actionResult.Result);
    }

    private IEnumerable<Course> CourseList()
    {
        IEnumerable<Course> courseList = [
            new Course()
                {
                    Id = 1,
                   CourseName = "Electronica A2",
                   CourseCode= "E2," ,
                   StartDate= DateTime.Now,
                   EndDate= DateTime.Now,
                   CoursePrice= 10.99M
                },
                new Course()
                {
                    Id = 2,
                   CourseName = "Mathemtics M2",
                   CourseCode= "E2," ,
                   StartDate= DateTime.Now,
                   EndDate= DateTime.Now,
                   CoursePrice= 15.99M
                }
            ]; ;
        return courseList;
    }

}
