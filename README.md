WEB API for schoolAdministration
----------------------------------

This API, written in C#, is intended as a backend for an Angular website for school administration.

A student can take 1 or more courses.

A student can create 1 or more studyplans.

With the help of a studyplan, the student can plan a learning period, for example for a specific exam.

A student can take an exam and view his results.

A teacher gives 1 or more courses.

A teacher can create 1 or more Exames.

A teacher can give exam grades for a specific student

<img width="945" height="456" alt="image" src="https://github.com/user-attachments/assets/53e084e8-9612-4aa4-b46d-04539626f07b" />

How to get the application :
----------------------------
* Click button Code
* Choose open with Visual Studio
* Click Clone

How to start the application :
------------------------------

* Setup the database in SQL-Server
* Adjust the connectionstring (DefaultSQLConnection) in appsettings.json with your credentinals.
* Start the application in Visual Studio by clicking the Startbutton (choose https)
  
  <img width="73" height="32" alt="image" src="https://github.com/user-attachments/assets/9f6ff179-07ca-4b6d-b389-a927057e22ea" />

* The application start now the Swagger-screen where you can explore the available endpoints.


Development:
-------------
<img width="577" height="125" alt="image" src="https://github.com/user-attachments/assets/e83d20a4-ed24-4706-940f-4e6fe16d67cf" />

<img width="1023" height="721" alt="image" src="https://github.com/user-attachments/assets/fa98041c-7225-4952-94ca-806aa133935a" />

<img width="1418" height="890" alt="image" src="https://github.com/user-attachments/assets/75d20064-34df-4985-ba5a-d2c450b6be59" />



Swagger :Exploring Endpoints
-----------------------------
![swaggerPrintScreenjpg](https://github.com/user-attachments/assets/3554497c-cc8b-4c8a-8f31-e1b02a726779)

UnitTests :
------------
![image](https://github.com/user-attachments/assets/96426350-2387-4e3e-a6c5-d1930969257e)

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
      .WriteTo.File("log/schoolManagementLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
  builder.Host.UseSerilog();

  StudentController:

  _logger.LogInformation("Getting all the students.")


Exploring Endpoints :
---------------------
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


Milestones :
-------------
27 unique visitors in 14 days.

<img width="1867" height="1067" alt="image" src="https://github.com/user-attachments/assets/e670fc3b-6277-4de7-8cb3-d4a5007ce55e" />



If you want to read more info about this API or the used technology :

https://github.com/KoenVerboven/SchoolAdministrationApi/tree/master/SchoolAdministration/Info















