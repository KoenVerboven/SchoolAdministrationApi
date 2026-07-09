

SELECT TOP(200) AspNetUsers.Id, AspNetUsers.Name, AspNetUsers.UserName, AspNetUsers.NormalizedUserName, AspNetUsers.Email, AspNetUsers.NormalizedEmail, AspNetUsers.EmailConfirmed, AspNetUsers.PasswordHash, 
                  AspNetUsers.SecurityStamp, AspNetUsers.ConcurrencyStamp, AspNetUsers.PhoneNumber, AspNetUsers.PhoneNumberConfirmed, AspNetUsers.TwoFactorEnabled, AspNetUsers.LockoutEnd, AspNetUsers.LockoutEnabled, 
                  AspNetUsers.AccessFailedCount, AspNetUsers.DateOfBirth, Students.FirstName, Students.LastName, Students.DateOfBirth AS Expr1
FROM     AspNetUsers INNER JOIN
                  Students ON AspNetUsers.Id = Students.ApplicationUserId
