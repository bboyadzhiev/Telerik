-- Write SQL statements to insert several records in the Users and Groups tables
USE TelerikAcademy
GO

-- Gropus data added in Task 18
IF OBJECT_ID('Users', 'U') IS NOT NULL
DELETE FROM Users
INSERT INTO Users(UserName, UserPassword, FullName, LastLogin, GroupID)
VALUES ('joro', 'joro12345', 'Joro Georgiev', GETDATE(), 1),
('pesho', 'pesho12345', 'Pesho Petrov', GETDATE(), 1),
('sasho', 'sasho12345', 'Sasho Alexandrov', '1998/1/1', 2),
('ivo', 'ivo12345', 'Ivo Ivanov', '1999/1/1', 2)

-- Adding ivo to the Gamma group
UPDATE Users
SET Users.GroupID = g.GroupID
	FROM Groups g
	JOIN Users u
	ON g.GroupName = 'Gamma' AND u.UserName = 'ivo'
GO
