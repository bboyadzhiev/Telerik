
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