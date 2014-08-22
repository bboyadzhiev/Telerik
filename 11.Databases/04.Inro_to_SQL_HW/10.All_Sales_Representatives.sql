USE TelerikAcademy
SELECT e.FirstName + ' ' + e.LastName as [Employee Name], d.Name as [Department Name], e.Salary, e.HireDate as [Hired Date],
CASE WHEN e.AddressID IS NULL
	THEN 'Unknown address'
	WHEN a.TownID is NULL
	THEN 'Unknown town'
	ELSE a.AddressText + ', ' + t.Name
END
 AS [Address]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
WHERE e.JobTitle = 'Sales Representative'