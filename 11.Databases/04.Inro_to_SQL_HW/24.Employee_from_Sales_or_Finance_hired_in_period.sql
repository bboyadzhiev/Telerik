USE TelerikAcademy
SELECT e.FirstName +' '+ 
CASE WHEN LEN(e.MiddleName) = 1 
	THEN  e.MiddleName+'. '
	WHEN e.MiddleName IS NULL
	THEN ''
	ELSE e.MiddleName + ' '
	END
 + e.LastName AS [Employee name],
 d.Name AS [Department],
 e.HireDate
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Finance' OR d.Name = 'Sales')
	AND 
	HireDate BETWEEN '1.1.1995' AND '1.1.2006'
	--('1/1/1995' <= e.HireDate and e.HireDate < '1/1/2006')
