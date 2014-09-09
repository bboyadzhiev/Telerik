-- Write a SQL query to find the count of all employees in each department and for each town.
USE TelerikAcademy
GO

SELECT COUNT(*) as [Emplayees Count] , d.Name as [Department], t.Name as [Town]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name, d.Name
