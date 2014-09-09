USE Company
GO

SELECT e.FirstName+' ' +e.LastName as [Name], e.YearlySalary as [Salary] 
FROM Employees e 
WHERE e.YearlySalary BETWEEN 100000 AND 150000
ORDER BY Salary ASC