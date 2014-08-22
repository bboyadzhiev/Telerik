/*Average salary per department*/
USE TelerikAcademy
SELECT d.Name, AVG(e.Salary) as [Average Salary]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
