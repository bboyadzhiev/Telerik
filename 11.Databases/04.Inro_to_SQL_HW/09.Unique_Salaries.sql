USE TelerikAcademy
SELECT Salary AS [Unique Salaries]
FROM Employees
EXCEPT
SELECT Salary AS [Unique Salaries]
FROM Employees
