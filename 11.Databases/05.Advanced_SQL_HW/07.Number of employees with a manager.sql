/*Number of employees with a manager*/
USE TelerikAcademy
SELECT COUNT(*) as [Number of employees with a manager]
FROM Employees e

WHERE e.ManagerID IS NOT NULL