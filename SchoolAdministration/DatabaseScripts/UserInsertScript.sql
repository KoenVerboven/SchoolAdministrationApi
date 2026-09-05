
use School2

-- [AspNetUsers] 

-- login : maddy@test.be   password: Admin123+ 
IF NOT EXISTS (SELECT * FROM [AspNetUsers] WHERE Id = 'e6a1b62f-f900-48ba-92a3-5603dc80fbd8')
BEGIN
     INSERT INTO [AspNetUsers]([Id], [Name], [UserName], [NormalizedUserName], [Email],
          [NormalizedEmail], [EmailConfirmed], [PasswordHash],
          [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed],
          [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled],
          [AccessFailedCount], [DateOfBirth], [FirstName], [LastName])
    VALUES(
        'e6a1b62f-f900-48ba-92a3-5603dc80fbd8', 'maddy', 'maddy@test.be', 'MADDY@TEST.BE', 'maddy@test.be',
        'MADDY@TEST.BE',  0, 'AQAAAAIAAYagAAAAEDppwYJ66aoGNsMyIGS6bCcxAhj5o0p0BtfmryIPgAJA6O7e1bi8m1AKthK28qQGhQ==',
        'RMT7ZRVAXPOE7RCDXLOOHEFHS4KYHS76', '35203908-14c9-45bf-a2a3-a76fb7e360df', NULL, 0,
        0, NULL, 1,
        0, '0001-01-01 00:00:00.0000000', '', ''
    )
END

-- [AspNetRoles]



-- [AspNetRoleClaims]

IF NOT EXISTS (SELECT * FROM [AspNetUsers] WHERE Id = 'f570f646-3f00-477f-a9cf-5053f03f0eaf')
BEGIN
    INSERT INTO [AspNetRoles]
      ([Id], [Name], [NormalizedName], [ConcurrencyStamp] )
      VALUES
      ('f570f646-3f00-477f-a9cf-5053f03f0eaf','SuperAdmin','SUPERADMIN',NULL)
END

IF NOT EXISTS (SELECT * FROM [AspNetUsers] WHERE Id = '7cc42937-7905-486c-bfcc-7c9319994565')
    BEGIN
    INSERT INTO [AspNetRoles]
      ([Id], [Name], [NormalizedName], [ConcurrencyStamp] )
      VALUES
      ('7cc42937-7905-486c-bfcc-7c9319994565','Admin','ADMIN',NULL)
END

IF NOT EXISTS (SELECT * FROM [AspNetUsers] WHERE Id = '906572c2-a601-4286-8e0f-8c03e0395e85')
BEGIN
    INSERT INTO [AspNetRoles]
      ([Id], [Name], [NormalizedName], [ConcurrencyStamp] )
      VALUES
      ('906572c2-a601-4286-8e0f-8c03e0395e85','Teacher','TEACHER',NULL)
END

IF NOT EXISTS (SELECT * FROM [AspNetUsers] WHERE Id = '4de15cdf-c009-4a7c-9134-245106e8ed02')
BEGIN
    INSERT INTO [AspNetRoles]
      ([Id], [Name], [NormalizedName], [ConcurrencyStamp] )
      VALUES
      ('4de15cdf-c009-4a7c-9134-245106e8ed02','Parent','PARENT',NULL)
END

IF NOT EXISTS (SELECT * FROM [AspNetUsers] WHERE Id = 'c09ca4e9-4fb1-4599-8213-4385b5ba9e68')
BEGIN
    INSERT INTO [AspNetRoles]
      ([Id], [Name], [NormalizedName], [ConcurrencyStamp] )
      VALUES
      ('c09ca4e9-4fb1-4599-8213-4385b5ba9e68','Student','STUDENT',NULL)
END

-- [AspNetUserRoles]

-- We give the user  maddy@test.be the role of Admin
IF NOT EXISTS (SELECT * FROM [AspNetUserRoles] WHERE UserId = 'e6a1b62f-f900-48ba-92a3-5603dc80fbd8')
BEGIN
    INSERT INTO [AspNetUserRoles]
      ( [UserId],[RoleId])
      VALUES ('e6a1b62f-f900-48ba-92a3-5603dc80fbd8', '7cc42937-7905-486c-bfcc-7c9319994565')
END

 
