/*Sales Department Employees Count*/
USE TelerikAcademy
SELECT COUNT(*) as [Sales Department Employees Count]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
