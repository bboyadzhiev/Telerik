-- Write a SQL query to find the number of employees in the "Sales" department

USE TelerikAcademy
GO

SELECT COUNT(*) as [Sales Department Employees Count]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
