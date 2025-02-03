WEB API for schoolAdministration
----------------------------------

This API, written in C#, is intended as a backend for an Angular website for school administration.

A student can take 1 or more courses.

A student can create 1 or more studyplans.

With the help of a studyplan, the student can plan a learning period, for example for a specific exam.

A student can take an exam and view his results.

A teacher gives 1 or more courses.


Student:
* GetAllStudents
* GetStudentById
* GetExamResultsByStudentId
* GetStudentByNameStartWith
* CreateStudent
* DeleteStudentById
* UpdateStudent

Teacher:
* GetAllTeachers
* GetTeacherById
* CreateTeacher
* DeleteTeacherById
* UpdateTeacher

Course:

* GetAllCoursers 
* GetCourseById 
* CreateCourse 
* DeleteCourse 
* UpdateCourse 
* SearchCourse on CourseName and CourseCode

Examen:
* GetAllExams
* GetExamById
* CreateExam
* DeleteExamById
* UpdateExamAsync

ExamenResult:
* GetAllExamResult
* GetExamResultById
* CreateExamResult
* DeleteExamById
* UpdateExamResult

StudyPlan:
* GetAllStudyPlans
* GetStudyPlanById, 
* CreateStudyPlan, 
* DeleteStudyPlanById,
* UpdateStudyPlan


Cross-origin-requests :
------------
Cors

Logging :
---------
Installed NuGet-packages :
* Serilog.AspNetCore
* Serilog.Sinks.file

With Serilog we can easly write our logs to a txt.file.

Program.cs:

  Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
      .WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
  builder.Host.UseSerilog();

  StudentController:

  _logger.LogInformation("Getting all the students.")


Exploring Endpoints :
-----------------------------------
 We use Swagger.


EntityFrameworkCore:
--------------------
Installed NuGet-packages :
* microsoft.entityframeworkcore.sqlserver\9.0.0
* entityframeworkcore.tools\9.0.0

We use code first.

By Migrations we keep our database in SQL-Server in Sync.

example:

Type in Package Manager Console:

Add-Migration InitialMigration

update-Database


Dependecy Injection :
--------------------
Why we use Dependecy Injection?

Dependency injection aims to separate the concerns of constructing objects and using them,
 leading to loosely coupled programs.


We use DI for injection from : studentRepository,logger and mapper

 public StudentController(
     IStudentRepository studentRepository,
     ILogger<StudentController> logger,
     IMapper mapper)

 In program.cs we must configure:
 
 builder.Services.AddScoped<IStudentRepository, StudentRepository>();

AutoMapper : 
-------------
Installed NuGet-package :  
* automapper

To map entities to DTO's and vice versa.

DTO stands for Data Transfer Objects

Why we need DTO's to communicate with the outside world?

Example : in our database we have fields to store 'insertDate' or 'insertedBy'

If we don't won't to share this fields with the outside world : we make a DTO 
without these fields.

We use par Controller 3 DTO's : one for update, one for insert, one for read

Why?

Because we do not need always the same data.

Example : for insert we do not need a ID, for a update is ID necessary.
 
MappingConfig:

 CreateMap<Student, StudentDTO>().ReverseMap();
 
In the Controller we can write some like this:

 _mapper.Map < StudentDTO > (student)
 
Here we map student to StudentDTO.

Versioning:
-----------
Installed NuGet-packages : 
* Microsoft.AspNetCore.Mvc.Versioning
* Microsoft.AspNetCore.Mvc.Versioning.ApiExlorer

  Program.cs :

 builder.Services.AddApiVersioning(options =>
 {
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
 });


Unittesting : 
-------------
add new project to solution : xUnit test Project

Installed Nuget-Packages:
* FluentAssertions
* Moq

Make a reference to SchoolAdministration project:

Right click project SchoolAdministrationTests

choose Project Reference

UnitTests :

![image](https://github.com/user-attachments/assets/91cc26be-4a32-4187-97e3-1de327700231)

Swagger :Exploring Endpoints

![localhost_7213_index html (2)](https://github.com/user-attachments/assets/37967a73-770c-444c-94ba-206baa648ff5)


