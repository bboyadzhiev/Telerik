
-- Write a SQL query to display the number of managers from each town.
USE TelerikAcademy
GO

SELECT t.Name as [Town], COUNT(e.EmployeeID) as [Managers Count]
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
WHERE e.EmployeeID IN(
	SELECT DISTINCT m.EmployeeID 
	FROM Employees m 
	INNER JOIN Employees e 
	ON m.EmployeeID = e.ManagerID)
GROUP BY t.Name