-- Write a SQL query to display the minimal employee salary by department 
-- and job title along with the name of some of the employees that take it
USE TelerikAcademy
GO

SELECT MIN(e.Salary) AS Salary, d.Name, e.JobTitle, MIN(e.FirstName + ' ' + e.LastName) as [Full Name]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name