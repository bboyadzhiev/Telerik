-- 29. Write a SQL to create table WorkHours to store work reports for each employee 
-- (employee id, date, task, hours, comments). 
-- Don't forget to define  identity, primary key and appropriate foreign key. 
--	Issue few SQL statements to insert, update and delete of some data in the table.
--	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
-- For each change keep the old record data, the new record data and the command (insert / update / delete).

USE TelerikAcademy
GO

CREATE TABLE WorkHours(
	WorkHoursID int IDENTITY,
	EmployeeID int NOT NULL,
	WorkHoursDate date NOT NULL,
	Task nvarchar(50) NOT NULL,
	TaskHours int NOT NULL,
	Comments nvarchar(250),
	CONSTRAINT PK_WorkHoursID PRIMARY KEY(WorkHoursID),
	CONSTRAINT FK_WorkHoursID_EmployeeID FOREIGN KEY (EmployeeID) REFERENCES Emplayees(EmployeeID)
	)
GO