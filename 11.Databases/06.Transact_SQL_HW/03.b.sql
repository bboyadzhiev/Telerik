
-- 03.b
-- Write a SELECT to test whether the function works as expected.
USE TransactSQL_HW_DB
GO

SELECT Balance, dbo.ufn_Interest(Balance, 1.1, 12) as Bonus
FROM Accounts


