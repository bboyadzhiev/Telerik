-- Write a SQL query to find the number of all employees that have manager.
USE TelerikAcademy
GO

SELECT COUNT(*) as [Number of employees with a manager]
FROM Employees e
WHERE e.ManagerID IS NOT NULL
