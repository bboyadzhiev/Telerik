/*Sales Department Average Salary*/
USE TelerikAcademy
SELECT AVG(e.Salary) as [Sales Department Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
