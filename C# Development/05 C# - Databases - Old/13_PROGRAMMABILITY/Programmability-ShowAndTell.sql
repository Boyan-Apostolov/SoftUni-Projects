CREATE FUNCTION udf_ProcessText(@text NVARCHAR(50))
RETURNS NVARCHAR(50)
AS
BEGIN
RETURN @text+ 'SomeText'
END

SELECT dbo.udf_ProcessText(e.FirstName) FROM Employees e

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL)
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(10)
	IF (@salary<30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF (@salary<=50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END
	RETURN @salaryLevel
END


SELECT FirstName,LastName,dbo.ufn_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees

CREATE OR ALTER PROC usp_OldestEmployees
AS
SELECT * FROM Employees
ORDER BY HireDate DESC

EXEC usp_OldestEmployees

CREATE OR ALTER PROC usp_OldestEmployeesWIthTotal(@totalEmployees INT)
AS
SELECT TOP(@totalEmployees)* FROM Employees
ORDER BY HireDate DESC

EXEC usp_OldestEmployeesWIthTotal 20

CREATE OR ALTER PROC usp_OldestEmployeesWIthTotalWithOutput(@totalEmployees INT,@result INT OUTPUT)
AS
SET @result = 1000

DECLARE @result INT
EXEC usp_OldestEmployeesWIthTotalWithOutput 20, @result OUTPUT

CREATE OR ALTER PROC usp_InsertProject(@employeeId INT,@projectId INT)
AS
BEGIN
	DECLARE @totalProjects INT
	SET @totalProjects= 
	(
	SELECT COUNT(*) FROM EmployeesProjects ep
	WHERE ep.EmployeeID = @employeeId
	)

	IF (@totalProjects > 3)
	BEGIN
		THROW 50000, 'EMPLOYEES CANNOT HAVE MORE THAN 3 PROJECTS',1
	END

	INSERT INTO EmployeesProjects VALUES (@employeeId, @projectId)

END

EXEC usp_InsertProject 3,3