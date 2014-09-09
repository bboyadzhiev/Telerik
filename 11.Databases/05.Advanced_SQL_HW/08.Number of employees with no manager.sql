-- Write a SQL query to find the number of all employees that have no manager.
USE TelerikAcademy
GO

SELECT COUNT(*) as [Number of employees with no manager]
FROM Employees e
WHERE e.ManagerID IS NULL
