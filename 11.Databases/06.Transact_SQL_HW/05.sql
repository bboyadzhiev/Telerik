
-- 05.
-- Add two more stored procedures WithdrawMoney( AccountId, money) 
-- and DepositMoney (AccountId, money) that operate in transactions.
USE TransactSQL_HW_DB
GO

CREATE FUNCTION dbo.usp_CheckAccount(@accountId int)
	RETURNS bit
AS
BEGIN
	DECLARE @account int
	SELECT @account = a.Id FROM Persons p
		JOIN Accounts a
		ON p.Id = a.PersonId AND a.Id = @accountId
	IF( @account IS NULL)
		BEGIN
		--PRINT('Account was not found!')
			RETURN 0
		END
	RETURN 1
END
GO

CREATE FUNCTION dbo.usp_CheckBalance(@accountId int, @money money)
	RETURNS bit
AS
BEGIN
	DECLARE @ballance money
	SELECT @ballance = a.Balance FROM Persons p
		JOIN Accounts a
		ON p.Id = a.PersonId AND a.Id = @accountId
	IF (@money < 0)
		BEGIN
		--PRINT('Money cannot be negative number')
		RETURN 0
		END
	IF(@ballance - @money < 0)
		BEGIN
	--	RAISERROR('Not enough money to withdraw!', 16, 1)
		RETURN 0
		END

	RETURN 1
END
GO

CREATE PROC dbo.usp_WithdrawMoney(@accountId int, @money money)
AS
BEGIN TRAN
	IF(dbo.usp_CheckAccount(@accountId) = 0 OR dbo.usp_CheckBalance(@accountId, @money) = 0)
	BEGIN
	RAISERROR('Transaction failed!', 16, 1)
	ROLLBACK TRAN
	RETURN
	END

	UPDATE a
	SET a.Balance = a.Balance - @money 
	FROM Persons p
		JOIN Accounts a
		ON p.Id = a.PersonId AND a.Id = @accountId
COMMIT TRAN
GO

EXEC dbo.usp_WithdrawMoney 1, 200
GO

CREATE PROC dbo.usp_DepositMoney(@accountId int, @money money)
AS
BEGIN TRAN
	IF(dbo.usp_CheckAccount(@accountId) = 0 OR @money < 0)
	BEGIN
	RAISERROR('Transaction failed!', 16, 1)
	ROLLBACK TRAN
	RETURN
	END

	UPDATE a
	SET a.Balance = a.Balance + @money 
	FROM Persons p
		JOIN Accounts a
		ON p.Id = a.PersonId AND a.Id = @accountId
COMMIT TRAN
GO

EXEC dbo.usp_DepositMoney 1, 2000
GO