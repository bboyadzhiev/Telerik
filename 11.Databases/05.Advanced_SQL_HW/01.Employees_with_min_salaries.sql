-- Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
-- Use a nested SELECT statement.
USE TelerikAcademy
GO

SELECT FirstName +' '+ 
CASE WHEN LEN(MiddleName) = 1 
	THEN  MiddleName+'. '
	WHEN MiddleName IS NULL
	THEN ''
	ELSE MiddleName + ' '
	END
 + LastName as 'Employees', Salary 
 FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)
