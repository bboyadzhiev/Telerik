-- Write a SQL query to display the current date and time in the following format 
-- "day.month.year hour:minutes:seconds:milliseconds".
USE TelerikAcademy
--SELECT CONVERT(VARCHAR(10),GETDATE(),104) +' ' + CONVERT(VARCHAR(12),GETDATE(),114) AS [Currnet Date and Time]
SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:fff');