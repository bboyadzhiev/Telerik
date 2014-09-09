
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