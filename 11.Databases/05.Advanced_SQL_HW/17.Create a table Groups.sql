-- Write a SQL statement to create a table Groups. 
-- Groups should have unique name (use unique constraint).
-- Define primary key and identity column
USE TelerikAcademy
GO

IF OBJECT_ID('Groups', 'U') IS NOT NULL
DROP TABLE Groups
GO

CREATE TABLE Groups(
	GroupID int IDENTITY,
	GroupName nvarchar(50) NOT NULL,
	CONSTRAINT PK_GroupID PRIMARY KEY(GroupID),
	CONSTRAINT uq_GroupName UNIQUE(GroupName)
	)
GO
