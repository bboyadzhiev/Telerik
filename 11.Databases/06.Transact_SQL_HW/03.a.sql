
-- 03. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
-- It should calculate and return the new sum. 

USE TransactSQL_HW_DB
GO

CREATE FUNCTION dbo.ufn_Interest(@sum money, @yearlyRate float, @months int)
RETURNS money
AS
BEGIN
	RETURN @sum * @yearlyRate * @months / 12
END