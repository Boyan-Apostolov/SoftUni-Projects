use SoftUni3
--1


--2


--3


--4
CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
BEGIN
	SELECT e.FirstName,e.LastName
	FROM Employees as e
	JOIN Addresses as a
	ON e.AddressID = a.AddressID
	JOIN Towns as t
	on a.TownID = t.TownID
	WHERE t.[Name] = @townName
END

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'
--5
CREATE FUNCTION ufn_GetSalaryLeve1(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7) = CASE
	WHEN @salary < 30000 THEN 'Low'
	WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
	ELSE 'High'
	END

	RETURN @salaryLevel;
END

SELECT Salary, dbo.ufn_GetSalaryLeve1(Salary) FROM Employees

--6
CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(7))
AS
BEGIN 
	Select FirstName,LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END

EXEC dbo.usp_EmployeesBySalaryLevel 'High'

--7
CREATE FUNCTION ufn_is_word_comprised(@setOfLetters varchar(50), @word varchar(50))
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT;
	DECLARE @currentLetter CHAR

	WHILE(@counter <= LEN(@word))
	BEGIN
		SET @currentLetter = SUBSTRING(@word, @counter,1);

		DECLARE @charIndex INT = CHARINDEX(@currentLetter,@setOfLetters);

		IF(@charIndex <= 0)
		BEGIN
			RETURN 0
		END

		SET @counter+=1;
	END
	RETURN 1;
END

SELECT dbo.ufn_is_word_comprised('oistmiafh','Sofia')

--8
CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerId INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId
	
	SELECT COUNT(*) FROM  Employees
	WHERE DepartmentID = @departmentId
END

--9


--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan @minBalance MONEY
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM Accounts as a
	JOIN AccountHolders AS ah
	ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName,ah.LastName
	HAVING SUM(a.Balance) > @minBalance
	ORDER BY ah.FirstName,ah.LastName
END

EXEC usp_GetGoldersWithBalanceHigherThan 10


--11


--12


--13
use Diablo

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS @output TABLE (SumCash DECIMAL(18,4))
AS
BEGIN
	INSERT INTO @output SELECT (SELECT SUM(Cash) as [SumCash] FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS [RowNUm] FROM UsersGames
	WHERE GameId IN (SELECT Id FROM Games WHERE [Name] = @gameName)) as [RowNumTalbe]
	WHERE [RowNUm] % 2 <> 0)
	RETURN;
END

SELECT * FROM ufn_CashInUsersGames ('Love in a mist')
--14


--15


--16


--17

