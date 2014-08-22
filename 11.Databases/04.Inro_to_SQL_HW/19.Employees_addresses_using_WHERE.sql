USE TelerikAcademy
SELECT
	CASE WHEN (e.AddressID IS NULL) OR (a.TownID is NULL)
		THEN 'Unknown address'
		ELSE a.AddressText + ', ' + t.Name
	END
	AS [Address], e.*
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID