WEB API for schoolAdministration
----------------------------------

This API, written in C#, is intended as a backend for an Angular website for school administration.

* A student can take courses, have diplomas and certificates, create studyplans, take an exam and view his(her) results.

* With the help of a studyplan, the student can plan a learning period, for example for a specific exam.

* A teacher can create courses,exams and homework.

* A teacher can give exam grades for a specific student

* ... and more

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
* Visual studio 2026 Community Edition

* Target framework :  .NET9.0

* SQL-Server 2022

* Database diagram :

<img width="1442" height="917" alt="image" src="https://github.com/user-attachments/assets/d1bab6b8-53b3-4deb-b9dd-7fb91db6560c" />


Swagger :Exploring Endpoints
-----------------------------
![swaggerPrintScreenjpg](https://github.com/user-attachments/assets/3554497c-cc8b-4c8a-8f31-e1b02a726779)

UnitTests :
------------
![image](https://github.com/user-attachments/assets/96426350-2387-4e3e-a6c5-d1930969257e)

add new project to solution : xUnit test Project

Installed Nuget-Packages:
* FluentAssertions
* Moq

Make a reference to SchoolAdministration project:

Right click project SchoolAdministrationTests

choose Project Reference

Cross-origin-requests :
------------
Cors

Program.cs:

<img width="641" height="207" alt="image" src="https://github.com/user-attachments/assets/7fec70e5-84f6-4549-b08f-7b17e3e438bc" />


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

Authentication:
---------------
Installed Nuget-packages :
* microsoft.aspnetcore.identity.entityframeworkcore\9.0.0\
* microsoft.aspnetcore.authentication.jwtbearer\9.0.3\

extra tables in SQL-Server:

<img width="265" height="161" alt="image" src="https://github.com/user-attachments/assets/f499c52f-6bd4-456c-bcba-89684df2201c" />



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

Versioning :
-----------

<img width="1465" height="66" alt="image" src="https://github.com/user-attachments/assets/51d90494-4088-4e7b-b9a2-cdf212506aa4" />


Installed NuGet-packages : 
* Microsoft.AspNetCore.Mvc.Versioning
* Microsoft.AspNetCore.Mvc.Versioning.ApiExlorer

  Program.cs :

 builder.Services.AddApiVersioning(options =>
 {
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
 });


More Info :
-----------


If you want to read more info about this API or the used technology :

https://github.com/KoenVerboven/SchoolAdministrationApi/tree/master/SchoolAdministration/Info















