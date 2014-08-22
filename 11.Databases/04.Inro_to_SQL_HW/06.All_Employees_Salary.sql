USE TelerikAcademy
SELECT FirstName +' '+ ISNULL(MiddleName,'') + ' ' + LastName as 'Employee', Salary 
FROM Employees
