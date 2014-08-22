-- Write a SQL statement to create a table Users .....
USE TelerikAcademy
GO

IF OBJECT_ID('Users', 'U') IS NOT NULL
DROP TABLE Users
GO

CREATE TABLE Users (
  UsersID int IDENTITY,
  UserName nvarchar(100) NOT NULL,
  UserPassword nvarchar(100) NOT NULL,
  FullName nvarchar(100) NOT NULL,
  LastLogin datetime,
  CONSTRAINT PK_Users PRIMARY KEY(UsersID),
  CONSTRAINT Users_Passwd CHECK (DATALENGTH([UserPassword]) > 5),
  CONSTRAINT uq_UserName UNIQUE (UserName)
)
GO

INSERT INTO Users(UserName, UserPassword, FullName, LastLogin)
VALUES ('joro', 'joro12345', 'Joro Georgiev', GETDATE()),
('pesho', 'pesho12345', 'Pesho Petrov', GETDATE()),
('sasho', 'sasho12345', 'Sasho Alexandrov', '1998/1/1'),
('ivo', 'ivo12345', 'Ivo Ivanov', '1999/1/1')
GO