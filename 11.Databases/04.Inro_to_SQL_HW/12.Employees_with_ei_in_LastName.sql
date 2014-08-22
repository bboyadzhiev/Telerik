USE TelerikAcademy
SELECT FirstName +' '+ 
CASE WHEN LEN(MiddleName) = 1 
	THEN  MiddleName+'. '
	WHEN MiddleName IS NULL
	THEN ''
	ELSE MiddleName + ' '
	END
 + LastName as 'Employees, with "ei" in last name' 
FROM Employees
WHERE LastName LIKE '%ei%'