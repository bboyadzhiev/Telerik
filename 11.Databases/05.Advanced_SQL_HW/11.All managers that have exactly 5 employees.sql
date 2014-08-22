-- Write a SQL query to find all managers that have exactly 5 employees. 
-- Display their first name and last name.
USE TelerikAcademy
SELECT  m.FirstName, m.LastName
FROM Employees e
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5
ORDER BY m.FirstName