-- Write a SQL statement that deletes all users without passwords (NULL password).

USE TelerikAcademy
GO

DELETE FROM Users
WHERE UserPassword IS NULL
GO