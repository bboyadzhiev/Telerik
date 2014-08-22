-- Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
-- Use the built-in LEN(str) function.
USE TelerikAcademy
SELECT e.*
FROM Employees e
WHERE LEN(e.LastName) = 5