USE TelerikAcademy
SELECT d.DepartmentID, d.Name as 'Department', e.FirstName +' '+ e.LastName as 'Manager' 
FROM Departments d
	INNER JOIN Employees e
		ON d.ManagerID = e.EmployeeID

