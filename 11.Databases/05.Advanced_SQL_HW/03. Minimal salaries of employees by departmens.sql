-- Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. 
-- Use a nested SELECT statement.
USE TelerikAcademy
GO

SELECT e.FirstName +' '+ 
CASE WHEN LEN(e.MiddleName) = 1 
	THEN  e.MiddleName+'. '
	WHEN e.MiddleName IS NULL
	THEN ''
	ELSE e.MiddleName + ' '
	END
 + e.LastName as 'Employees', e.Salary, d.Name AS [Department Name]
FROM Employees e, Departments d
WHERE e.Salary = 
	(
	SELECT MIN(e.Salary) 
	FROM Employees e
	WHERE e.DepartmentID = d.DepartmentID
	)
ORDER BY d.Name ASC
