
-- Populate database School2 with testdata
-- Note:
-- Filling in the tables must follow a specific order.
-- First, the tables that do not have foreign key dependencies should be filled (e.g., Addresses, Schools, Students, Teachers, Courses).
use School2

  Insert into [Addresses]
      (
       [StreetAndNumber]
      ,[BusNumber]
      ,[Zipcode]
      ,[City]
      ,[CountryCode]
      )
      values
      ('Hoofdweg 12',null,2300,'Turnhout','BE'),
      ('Antwerpsesteenweg 300',null,2300,'Turnhout','BE'),
      ('Atomiumlaan 1',null,3000,'Brussel','BE'),
      ('Grotebaan 78',null,2000,'Antwerpen','BE')


  Insert into [Schools]
      (
       [Name]
      ,[StreetAndNumber]
      ,[ZipCode]
      ,[CountryId]
      ,[ContactPhone]
      ,[ContactEmail]
      ,[Website]
      ,[LogoUrl]
      ,[Description]
      ,[SchoolType]
      ,[NumberOfStudents]
      ,[NumberOfTeachers]
      ,[EstablishedYear]
      ,[Facilities]
      ,[SocialMedia]
      ,[CreatedBy]
      ,[CreatedAt]
      ,[UpdatedBy]
      ,[UpdatedAt]
  )
  values
  ('Vrije technische school turnhout','Hoofdweg', 2300,1,'541646464','vtt@gmail.com', 'www.vtst.com',null,null,null,null,null,null,null,null,'system',getdate(),null,null),
  ('Universiteit Turnhout','Kerkstraat 45 ', 2300,1,'5415287678','ut@gmail.com', 'www.UTurnhout.com',null,null,null,null,null,null,null,null,'system',getdate(),null,null),
  ('Basisschool Turnhout','Merodelei 500 ', 2300,1,'753993387','ut@gmail.com', 'www.BSchoolTurnhout.com',null,null,null,null,null,null,null,null,'system',getdate(),null,null),
  ('Kleuterschool Turnhout','Merodelei 501 ', 2300,1,'87638763876','k@gmail.com', 'www.KSchoolTurnhout.com',null,null,null,null,null,null,null,null,'system',getdate(),null,null)


  Insert into [Students]
      (
      [FirstName]
      ,[LastName]
      ,[Email]
      ,[Phone]
      ,[DateOfBirth]
      ,[Gender]
      ,[RegistrationDate]
      ,[Picture]
      )
      values
      ( 'Koen','Verboven','koen@test.be' , '345464646','2003-06-01  10:00:00',1,'2003-06-01  10:00:00','/StudentPictures/Student1.jpg'),
      ( 'Maddy','Poels','maddy@test.be' , '345464646','2002-06-01  10:00:00',1,'2003-06-02  10:00:00',null)


  Insert into [StudentAddresses]
  (
       [StudentId]
      ,[AddressId]
      ,[AddressOrder]
      ,[RegistrationDate]
      ,[RegisteredByUserId]
  )
  values
  (1,2,1,'2026-07-01  10:00:00',1),
  (1,3,2,'2026-07-01  11:00:00',1),
  (5,4,1,'2026-07-01  10:00:00',1),
  (5,1,2,'2026-07-01  11:00:00',1)


  Insert into [Teachers]
      (
       [FirstName]
      ,[LastName]
      ,[DateOfBirth]
      ,[Gender]
      ,[Email]
      ,[Phone]
      ,[HireDate]
      ,[LeaveDate]
      ,[MaritalStatusId]
  )
  values
  ('Piet','Smulders', '1985-06-01  10:00:00',1, 'Piet@test.be','04846844','2002-06-01  10:00:00',null,1),
  ('Linda','Janssens', '1989-07-08  10:00:00',2, 'Linda@test.be','0484444545','2008-06-01  10:00:00',null,2)

  Insert into [Courses]
  (
       [CourseName]
      ,[CourseCode]
      ,[CourseDescription]
      ,[StartDate]
      ,[EndDate]
      ,[CoursePrice]
      ,[MaxNumberOfStudents]
  )
  Values
  ('Classic Guitar','G1','Guitar beginner','2026-06-01  10:00:00','2026-06-05  10:00:00',22,22),
  ('Piano','P1','Piano beginner','2026-06-05  10:00:00','2026-06-07  12:00:00',19,10)

  Insert into [SchoolDepartments]
  (
     [Name]
     ,[SchoolId]
     ,[IsActive]
     ,[Description]
     ,[LocationWithinTheSchool]
     ,[CreatedAt]
  )
  Values
  ('Electronica2',1,1,'',null,getdate()),
  ('Mechanica2',1,1,'',null,getdate()),
  ('Bouw',1,1,'',null,getdate())

  -- inert into SchoolClasses
  -- insert into StudentClassRegistrations
  -- insert into [TeacherAddresses]
