-- Write a SQL statement to add a column GroupID to the table Users. 
-- Fill some data in this new column and as well in the Groups table. 
-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
USE TelerikAcademy
GO

-- Write a SQL statement to add a column GroupID to the table Users. 
IF OBJECT_ID('Users', 'U') IS NOT NULL
ALTER TABLE Users
ADD GroupID int
GO

-- Fill some data in this new column and as well in the Groups table. 
-- !!! Users data should already be filled in Task 15 !!!
IF OBJECT_ID('Groups', 'U') IS NOT NULL
INSERT INTO Groups(GroupName)
VALUES 
	('Alpha'), 
	('Beta'), 
	('Gamma'), 
	('Delta')
GO

-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
IF OBJECT_ID('Users', 'U') IS NOT NULL
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID)
GO
