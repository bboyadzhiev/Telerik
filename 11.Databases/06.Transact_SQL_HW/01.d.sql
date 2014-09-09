 
 -- 01.d
 -- Write a stored procedure that selects the full names of all persons.
USE TransactSQL_HW_DB
GO

CREATE PROC dbo.usp_PersonsFullNames
AS
	SELECT FirstName + ' ' + LastName 
	FROM Persons
GO

EXEC dbo.usp_PersonsFullNames