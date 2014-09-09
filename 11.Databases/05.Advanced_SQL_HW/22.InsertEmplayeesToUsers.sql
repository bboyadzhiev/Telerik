-- Write SQL statements to insert in the Users table the names of all employees from the Employees table. 
-- Combine the first and last names as a full name. 
-- For username use the first letter of the first name + the last name (in lowercase). 
-- Use the same for the password, and NULL for last login time.

USE TelerikAcademy
GO

INSERT INTO Users(UserName, UserPassword, FullName, LastLogin)
SELECT 
	LOWER(e.FirstName+e.LastName),
	LOWER(e.FirstName+e.LastName),
	e.FirstName +' '+ 
	CASE WHEN LEN(e.MiddleName) = 1 
		THEN  e.MiddleName+'. '
		WHEN e.MiddleName IS NULL
		THEN ''
		ELSE e.MiddleName + ' '
		END
	 + e.LastName,
	 NULL
FROM Employees e 
GO
