USE TelerikAcademy
SELECT FirstName +' '+ 
CASE WHEN LEN(MiddleName) = 1 
	THEN  MiddleName+'. '
	WHEN MiddleName IS NULL
	THEN ''
	ELSE MiddleName + ' '
	END
 + LastName as 'Employees, starting with "SA"' 
FROM Employees
WHERE FirstName LIKE 'sa%'