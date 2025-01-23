WEB API for schoolAdministration
----------------------------------

Visual Studio 2022 
Target framework : .NET 9.0

We have CRUD-operations for:

Student, Teacher, Course, Exam, 
ExamenResult, StudyPlan, StudyPlanPart

Note :
If you like my project; please give me a star!
Thanks!


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

Example of tests:

![image](https://github.com/user-attachments/assets/91cc26be-4a32-4187-97e3-1de327700231)



![image](https://github.com/user-attachments/assets/6cbeb1ce-4168-425f-a7fa-389a75b431d7)




