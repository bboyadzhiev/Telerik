USE TelerikAcademy
SELECT
	CASE WHEN (e.AddressID IS NULL) OR (a.TownID is NULL)
		THEN 'Unknown address'
		ELSE a.AddressText + ', ' + t.Name
	END
	AS [Address], e.*
FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
