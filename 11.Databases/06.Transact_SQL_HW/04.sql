
-- 04
-- Create a stored procedure that uses the function from the previous example 
-- to give an interest to a person's account for one month. 
-- It should take the AccountId and the interest rate as parameters.
USE TransactSQL_HW_DB
GO

CREATE PROC dbo.usp_UpdateMonthlyInterest(@accountId int, @interestRate float)
AS
UPDATE a
SET a.Balance = a.Balance + dbo.ufn_Interest(a.Balance, @interestRate, 1) 
FROM Persons p
	JOIN Accounts a
	ON p.Id = a.PersonId AND a.Id = @accountId
GO

-- should be 1000
EXEC dbo.usp_UpdateMonthlyInterest @accountId = 1, @interestRate = 0.2
-- now should be 1016.6667