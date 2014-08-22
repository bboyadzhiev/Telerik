/*Minimal salaries of employees by departmens*/
USE TelerikAcademy
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