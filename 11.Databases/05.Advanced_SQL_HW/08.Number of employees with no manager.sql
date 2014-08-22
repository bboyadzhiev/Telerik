/*Number of employees with no manager*/
USE TelerikAcademy
SELECT COUNT(*) as [Number of employees with no manager]
FROM Employees e
WHERE e.ManagerID IS NULL