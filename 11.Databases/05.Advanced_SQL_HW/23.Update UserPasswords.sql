-- Write a SQL statement that changes the password to NULL for all users 
-- that have not been in the system since 10.03.2010.

USE TelerikAcademy
GO

UPDATE Users
SET UserPassword = NULL
WHERE LastLogin < '20100310' 