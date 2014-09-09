USE master
GO

CREATE DATABASE PerformanceDB_HW
GO

USE PerformanceDB_HW
GO
-- Task 1 --
CREATE TABLE Logs(
	LogId int NOT NULL IDENTITY,
	LogDate datetime,
	EntryText nvarchar(200),
	CONSTRAINT PK_Logs_LogId PRIMARY KEY (LogId)
)
GO

CREATE PROC usp_AppendLogs
AS
DECLARE @i int
SET @i = 1;
WHILE(@i < 500000)  -- my machine is way too slow for 10 000 000 records, set to 500 000
	BEGIN
		DECLARE @newDate datetime
		SET @newDate = DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
		INSERT INTO Logs (LogDate, EntryText)
		VALUES(@newDate, 'Log entry ' + CONVERT(nvarchar(8), @i))
		SET @i = @i + 1;
	END
GO

EXEC usp_AppendLogs
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
-- took 4 minutes, 21 seconds

SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2010 AND YEAR(l.LogDate) > 2001
--took 5 seconds

-- Task 2 --
CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)
DROP INDEX Logs.IDX_Logs_LogDate
-- 4 secs

SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2010 AND YEAR(l.LogDate) > 2001
-- took 2 seconds

-- Task 3 --
-- Full text index creation failed, said: "full text not installed" or something
CREATE INDEX IDX_Logs_EntryText ON Logs(EntryText)
-- 5 secs

SELECT *
FROM Logs
WHERE YEAR(LogDate) < 2010 AND YEAR(LogDate) > 2001
-- took 1 second or less