
-- 02. Create a stored procedure that accepts a number as a parameter 
-- and returns all persons who have more money in their accounts than the supplied number.
USE TransactSQL_HW_DB
GO


CREATE PROC dbo.usp_PersonsWithMoreMoneyThan
	@moneyLimit money
AS
	SELECT p.*, a.Balance
	FROM Persons p
	JOIN Accounts a
	ON p.Id = a.PersonId
	WHERE a.Balance > @moneyLimit
GO

EXEC dbo.usp_PersonsWithMoreMoneyThan 7000
