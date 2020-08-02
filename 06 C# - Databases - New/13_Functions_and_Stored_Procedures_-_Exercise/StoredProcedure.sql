--1
GO
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName,LastName
	FROM Employees
	WHERE Salary > 35000
END
GO

EXEC usp_GetEmployeesSalaryAbove35000

--2
go
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18,4))
AS
BEGIN 
	SELECT FirstName,LastName
	FROM Employees
	WHERE Salary >= @minSalary
END
go

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--3
go
CREATE PROC usp_GetTownsStartingWith(@searchedString NVARCHAR(50))
AS
BEGIN
	DECLARE @stringCount int = LEN(@searchedString)
	SELECT [Name]
		FROM Towns
		WHERE LEFT([Name],@stringCount) = @searchedString
END
go

EXEC usp_GetTownsStartingWith 'b'

--4
GO
CREATE PROC usp_GetEmployeesFromTown(@townName VARCHAR(50))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees as e
	JOIN Addresses as a ON e.AddressID = a.AddressID
	JOIN Towns as t ON a.TownID = t.TownID
	WHERE t.Name = @townName
END
GO

EXEC usp_GetEmployeesFromTown 'Sofia'

--5
go
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN 
	DECLARE @salaryLevel VARCHAR(10);
	
	IF (@salary < 30000) SET @salaryLevel = 'Low';
	ELSE IF (@salary >= 30000 AND @salary <= 50000) SET @salaryLevel = 'Average'
	ELSE SET @salaryLevel = 'High'

	RETURN @salaryLevel
END
go

--6
go
CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
BEGIN
	SELECT FirstName,LastName 
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END
go

EXEC usp_EmployeesBySalaryLevel 'High'

--7
go
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50)) 
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1;

	WHILE(@i <= LEN(@word))
	BEGIN
		DECLARE @currChar CHAR = SUBSTRING(@word,@i,1)
		DECLARE @charIndex INT = CHARINDEX(@currChar, @setOfLetters)

		IF (@charIndex = 0) RETURN 0
		
		SET @i = @i +1
	END
	RETURN 1
END
go

SELECT dbo.ufn_IsWordComprised('suoiflja', 'Sofia')
--8
go
CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
BEGIN
		DELETE FROM EmployeesProjects
		WHERE EmployeeID IN (
			SELECT EmployeeId
				FROM Employees
				WHERE DepartmentID = @departmentId)

		UPDATE Employees
		SET ManagerID = NULL
		WHERE ManagerID IN (
			SELECT EmployeeId
				FROM Employees
				WHERE DepartmentID = @departmentId)

		ALTER TABLE Departments
		ALTER COLUMN ManagerID INT

		UPDATE Departments
		SET ManagerID = NULL
		WHERE ManagerID IN (
			SELECT EmployeeId
				FROM Employees
				WHERE DepartmentID = @departmentId)

		DELETE FROM Employees
		WHERE DepartmentID = @departmentId

		DELETE FROM Departments
		WHERE DepartmentID = @departmentId

		SELECT COUNT(*) FROM Employees
		WHERE DepartmentID = @departmentId
END
go

--9
go
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(FirstName,' ',LastName) AS [Full Name] 
		FROM AccountHolders
END
go

EXEC usp_GetHoldersFullName

--10
go
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@minBalance DECIMAL(18,4))
AS
BEGIN
	SELECT FirstName,LastName FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	GROUP BY FirstName,LastName
	HAVING SUM(Balance) > @minBalance
	ORDER BY FirstName,LastName
END
go

EXEC usp_GetHoldersWithBalanceHigherThan 25000

--11
go
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4),@yir FLOAT, @yearsCount INT)
RETURNS DECIMAL(18,4)
AS 
BEGIN
	DECLARE @futureFalue DECIMAL(18,4)
	SET @futureFalue = @sum * (POWER((1+@yir),@yearsCount))
	RETURN @futureFalue
END
go

SELECT dbo.ufn_CalculateFutureValue(1000,0.1,5)

--12
GO
CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate DECIMAL(5,2))
AS
BEGIN
SELECT  ah.Id AS [Account Id],
		FirstName AS [First Name],
		LastName AS [Last Name],
		Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(Balance,@interestRate,5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId
END

EXEC usp_CalculateFutureValueForAccount 1,0.1
go
--13
go
CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE 
AS
RETURN SELECT(
			SELECT SUM(Cash) AS SumCash 
			FROM 
				(SELECT g.Name,ug.Cash, ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) As RowNum
				FROM Games AS g
				JOIN UsersGames AS ug ON g.Id=ug.GameId
				WHERE g.Name = @gameName) AS RowNumQuerry
			WHERE [RowNum] % 2 <> 0) AS [SumCash]

go

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')
