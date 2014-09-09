-- Write a SQL query to find all departments and the average salary for each of them.
USE TelerikAcademy
GO

SELECT d.Name, AVG(e.Salary) as [Average Salary]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
