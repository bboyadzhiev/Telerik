USE Company
GO

SELECT e.id, e.FirstName+' ' +e.LastName as [Employee Name], p.Id, p.Name as [Project Name], d.Name as [Department Name],
ep.StartDate as [Start Date], ep.EndDate as [End Date], r.Id
	FROM Employees e
	JOIN Departments d ON e.DepartmentId = d.Id
	JOIN EmployeesProjects ep ON e.id = ep.EmployeeId
	JOIN Projects p ON ep.ProjectId = p.Id
	JOIN Reports r ON e.Id = r.EmployeeId

