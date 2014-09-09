-- Write a SQL query to display the average employee salary by department and job title.
USE TelerikAcademy
GO

SELECT 
e.JobTitle, d.Name, AVG(e.Salary)
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d. DepartmentID
GROUP BY e.JobTitle, d.Name
GO