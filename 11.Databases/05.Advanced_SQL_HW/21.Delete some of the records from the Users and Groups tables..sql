-- Write SQL statements to delete some of the records from the Users and Groups tables.
USE TelerikAcademy
GO
 
 DELETE FROM Users
 WHERE UserName = 'ivo'
 DELETE FROM Groups
 WHERE GroupName = 'Gamma'
 GO
 