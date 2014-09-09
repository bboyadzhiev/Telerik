
-- Write a SQL query to display the town where maximal number of employees work.
USE TelerikAcademy
GO

SELECT TOP 1 t.Name as [Town], COUNT(*) AS [Emplayees count] 
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC

 