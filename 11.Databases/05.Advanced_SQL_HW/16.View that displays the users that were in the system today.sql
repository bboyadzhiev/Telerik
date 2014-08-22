-- Write a SQL statement to create a view that displays the users 
-- from the Users table that have been in the system today
USE TelerikAcademy
GO

CREATE VIEW V_Users_Today AS
SELECT * FROM Users
WHERE CONVERT(date,LastLogin)=CONVERT(DATE,getdate())
GO

SELECT * FROM V_Users_Today