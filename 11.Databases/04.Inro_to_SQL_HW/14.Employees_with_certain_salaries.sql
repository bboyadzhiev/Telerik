USE TelerikAcademy
SELECT FirstName +' '+ 
CASE WHEN LEN(MiddleName) = 1 
	THEN  MiddleName+'. '
	WHEN MiddleName IS NULL
	THEN ''
	ELSE MiddleName + ' '
	END
 + LastName as 'Employees', Salary 
FROM Employees
WHERE Salary = 25000 OR (Salary = 14000 OR (Salary = 12500 OR Salary = 23600))
ORDER BY FirstName ASC