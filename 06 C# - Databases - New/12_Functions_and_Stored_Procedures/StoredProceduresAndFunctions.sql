DECLARE @Year smallint = 2025;
DECLARE @Year2 int = 2021;

SET @Year = 2020

SELECT @Year AS FirstYear, @Year2 AS SecondYear
---

IF @Year = DATEPART(year,GETDATE())
	SELECT GETDATE()
ELSE IF @Year = 2029
	SELECT '2029!'
ELSE
	SELECT 'No match!'
---

SELECT CASE @Year
	WHEN 2020 THEN  '2020!'
	ELSE 'Dont know!'
	END
---

DECLARE @Year3 INT = 2000

WHILE @Year3 <= 2005
BEGIN
SELECT @Year3
SET @Year3+=1
END
---

SELECT GETDATE(), DATEPART(MONTH,'2010-01-01'), POWER(2,10),Pi()
---

DECLARE @tablename NVARCHAR(50) = 'Employees'
EXEC('SELECT COUNT(*) FROM '+ @tablename)
---

go
CREATE OR ALTER FUNCTION udf_Pow(@Base int, @Exp int)
RETURNS BIGINT
AS
BEGIN
	DECLARE @result BIGINT = 1;
	WHILE (@Exp>0)
	BEGIN
		SET @result = @result * @Base;
		SET @Exp = @Exp -1;
	END
	RETURN @result;
END

go
SELECT dbo.udf_Pow(2,10), POWER(2,10)
---
go
CREATE OR ALTER FUNCTION udf_DifferenceBetweenTwoWeeks(@StartDate DATETIME,@EndDate DATETIME)
RETURNS INT
BEGIN
	IF(@EndDate IS NULL)
		SET @EndDate = GETDATE();
	return DATEDIFF(WEEK,@StartDate,@EndDate);
END
go

SELECT dbo.udf_DifferenceBetweenTwoWeeks('2020-01-01', NULL)

SELECT dbo.udf_DifferenceBetweenTwoWeeks(StartDate,EndDate) FROM Projects
---
go
CREATE OR ALTER FUNCTION udf_GetEmployeesCountByYear(@Year INT)
RETURNS TABLE
AS
RETURN
(
	SELECT *
		FROM Employees
		WHERE DATEPART(year,HireDate) = @Year
)
go

SELECT * FROM dbo.udf_GetEmployeesCountByYear(2000)
---

go
CREATE OR ALTER FUNCTION udf_Squares(@Count INT)
RETURNS @randomNumbers TABLE(
	[Id] INT PRIMARY KEY IDENTITY,
	[Square] bigINT
)
AS
BEGIN
	DECLARE @i int = 1;

	WHILE(@i <= @Count)
	BEGIN
	INSERT INTO @randomNumbers(Square) VALUES (@i*@i)
	SET @i = @i + 1;
	END
	RETURN
END
go

SELECT * FROM dbo.udf_Squares(10)
---
go
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(10)
BEGIN
	IF (@Salary < 30000) RETURN 'Low';
	ELSE IF (@Salary <= 50000) RETURN 'Average';
	ELSE RETURN 'High';
	RETURN '';
END
go

SELECT dbo.ufn_GetSalaryLevel(300000)
---
go
CREATE OR ALTER PROC sp_GetEmployeesByExxperience
AS
	SELECT *
		fROM Employees
		WHERE DATEDIFF(year,HireDate,GETDATE()) > 19
GO

EXEC sp_GetEmployeesByExxperience
---

EXEC sp_depends 'dbo.Employees'
EXEC sp_columns 'Employees'
---

go
CREATE OR ALTER PROC sp_GetEmployeesByExxperienceWithYear(@Year INT = 19, @MinSalary MONEY = 10000, @Count INT OUTPUT)
AS
	SET @Count = (SELECT *
		fROM Employees
		WHERE DATEDIFF(year,HireDate,GETDATE()) > @Year
			AND Salary > @MinSalary
			)
GO

EXEC sp_GetEmployeesByExxperienceWithYear 20, 12500
EXEC sp_GetEmployeesByExxperienceWithYear @Year = 20, @MinSalary = 12500

DECLARE @Count INT;
EXEC sp_GetEmployeesByExxperienceWithYear @Count OUTPUT;
SELECT @Count
---

THROW 50001, 'Null value for project date', 1

IF (@@ERROR> 0) SELECT 'error occured'
---

BEGIN TRY
	SELECT 0/0
END TRY
BEGIN CATCH
	SELECT @@ERROR
END CATCH
---

SELECT * FROM sys.messages
---
go
CREATE OR ALTER PROC sp_InsertEmployeeForProject(@EmployeeId INT,@ProjectId INT)
AS
	DECLARE @projectsCount INT
	SET @projectsCount = (SELECT COUNT(*) from dbo.EmployeesProjects WHERE EmployeeID = @EmployeeId)

	IF(@projectsCount >= 3)
		THROW 50001, 'Employee already has 3 or more projects',1
		INSERT INTO EmployeesProjects(EmployeeID,ProjectID)
		VALUES(@EmployeeID,@ProjectID)
GO

EXEC sp_InsertEmployeeForProject 1,1 