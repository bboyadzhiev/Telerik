-- 01.a
-- Create a database with two tables: 
-- Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance). 
-- Insert few records for testing. Write a stored procedure that selects the full names of all persons.
CREATE DATABASE TransactSQL_HW_DB
GO

USE TransactSQL_HW_DB
GO

CREATE TABLE Persons(
	Id int IDENTITY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN nvarchar(50) NOT NULL,
	CONSTRAINT PK_PersonsId PRIMARY KEY(Id),
	CONSTRAINT uq_SSN UNIQUE(SSN)
	)
GO

CREATE TABLE Accounts(
	Id int IDENTITY,
	PersonId nvarchar(50) NOT NULL,
	Balance money,
	CONSTRAINT PK_AccountsId PRIMARY KEY(Id),
	CONSTRAINT FK_AccountId_PersonId FOREIGN KEY (Id) REFERENCES Persons(Id)
	)
GO

-- 01.b
-- Insert few records for testing
USE TransactSQL_HW_DB
GO

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES ('Georgi', 'Georgiev', '123123123'),
('Petar', 'Petrov', '456456456'),
('Sasho', 'Alexandrov', '789789789'),
('Ivan', 'Ivanov', '555666777'),
('Kiril', 'Kirov', '111222333'),
('Maria', 'Petrova', '245223777')
GO

-- 01.c
-- Insert few records for testing
USE TransactSQL_HW_DB
GO

INSERT INTO Accounts(PersonId, Balance)
VALUES (1, 1000.0),
(2, 6636.5),
(3, 8227.53),
(4, 111282.234)
GO 
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
-- 03.b
-- Write a SELECT to test whether the function works as expected.
USE TransactSQL_HW_DB
GO

SELECT Balance, dbo.ufn_Interest(Balance, 1.1, 12) as Bonus
FROM Accounts

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

-- 06
-- Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
-- Add a trigger to the Accounts table that enters a new entry 
-- into the Logs table every time the sum on an account changes.
USE TransactSQL_HW_DB
GO

CREATE TABLE Logs(
	LogID int IDENTITY NOT NULL,
	AccountID int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
	CONSTRAINT PK_LogID PRIMARY KEY(LogID),
	CONSTRAINT FK_LogID_AccountId FOREIGN KEY (AccountID) REFERENCES Accounts(Id)
	)
GO

CREATE TRIGGER tr_AccountBalanceChange ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs (AccountID, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	-- I think this is better than just 'FROM inserted i, deleted d'
	FROM inserted i
		JOIN deleted d
		ON d.Id = i.Id
END
GO

EXEC dbo.usp_DepositMoney 1, 2000

-- 07
-- Define a function in the database TelerikAcademy that returns all Employee's names 
-- (first or middle or last name) and all town's names that are comprised of given set of letters. 
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
USE TelerikAcademy
GO

CREATE FUNCTION dbo.ufn_HasLetters (@word nvarchar(150), @letters nvarchar(50))
RETURNS bit
AS
BEGIN
	DECLARE @lettersLen int = LEN(@letters),
	@matches int = 0,
	@currentChar nvarchar(1)
	WHILE(@lettersLen > 0)
	BEGIN
		SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
		IF(CHARINDEX(@currentChar, @word, 0) > 0)
			BEGIN
				SET @matches += 1
				SET @lettersLen -= 1
			END
		ELSE
			SET @lettersLen -= 1
	END
	IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
		RETURN 1
	RETURN 0
END
GO

CREATE FUNCTION dbo.ufn_EmployeeAndTownNames(@lettersSet nvarchar(50))
RETURNS TABLE
AS
RETURN (
	SELECT e.FirstName, e.LastName, t.Name as [Town]
	FROM Employees e
		JOIN Addresses a
		ON	e.AddressID = a.AddressID
		JOIN Towns t
		ON t.TownID = a.TownID
	WHERE 
	dbo.ufn_HasLetters(e.FirstName, @lettersSet) = 1
	AND dbo.ufn_HasLetters(e.MiddleName, @lettersSet) = 1
	AND dbo.ufn_HasLetters(e.LastName, @lettersSet) = 1
	OR dbo.ufn_HasLetters(t.Name, @lettersSet) = 1
	)
GO

SELECT * FROM dbo.ufn_EmployeeAndTownNames('oistmiahf')