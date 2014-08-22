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
WHERE Salary = (SELECT MIN(Salary) FROM Employees)