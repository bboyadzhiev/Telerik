USE Company
GO

SELECT d.Id as [Department ID],
	 d.Name as [Department Name], 
	 Count(e.Id) as [Employees Count] 
	 FROM Departments d
 LEFT JOIN Employees e
 ON d.Id = e.DepartmentId
 Group by d.Id, d.Name
 ORDER BY [Employees Count] DESC