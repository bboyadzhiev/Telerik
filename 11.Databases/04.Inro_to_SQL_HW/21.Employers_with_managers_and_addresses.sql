/* Address and town might be null !!! */
/* Includes the bosses */
USE TelerikAcademy
SELECT
e.FirstName +' '+ 
CASE WHEN LEN(e.MiddleName) = 1 
	THEN  e.MiddleName+'. '
	WHEN e.MiddleName IS NULL
	THEN ''
	ELSE e.MiddleName + ' '
	END
 + e.LastName AS [Employee],
m.FirstName +' '+ 
CASE WHEN LEN(m.MiddleName) = 1 
	THEN  m.MiddleName+'. '
	WHEN m.MiddleName IS NULL
	THEN ''
	ELSE m.MiddleName + ' '
	END
 + m.LastName AS [Manager],
CASE WHEN (e.AddressID IS NULL) OR (a.TownID is NULL)
		THEN 'Unknown address'
		ELSE a.AddressText + ', ' + t.Name
	END
	AS [Employee's Address]
FROM Employees e 
	FULL JOIN Employees m	
	ON e.ManagerID = m.EmployeeID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID