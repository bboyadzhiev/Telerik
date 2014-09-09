-- Write a SQL query to find the names and salaries of the employees that have 
-- a salary that is up to 10% higher than the minimal salary for the company.

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
WHERE Salary  <= 1.1 * (SELECT MIN(Salary) FROM Employees)
