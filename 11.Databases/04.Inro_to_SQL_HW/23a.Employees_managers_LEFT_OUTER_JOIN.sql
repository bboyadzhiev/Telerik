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
 + m.LastName AS [Manager]
FROM Employees e 
	LEFT OUTER JOIN Employees m	
	ON e.ManagerID = m.EmployeeID
