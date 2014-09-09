
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