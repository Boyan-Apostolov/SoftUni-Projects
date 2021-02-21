-----1
create database Service
go
use Service
go

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(50) NOT NULL,
	Name VARCHAR(50),
	Birthdate DATETIME2,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)
CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Status(
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	Description VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)
go
-----2
INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId) VALUES
('Marlo','O''Malley',	'1958-9-21',	1),
('Niki','Stanaghan',	'1969-11-26',	4),
('Ayrton','Senna',	'1960-03-21',	9),
('Ronnie','Peterson',	'1944-02-14',	9),
('Giovanna','Amati',	'1959-07-20',	5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId) VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)
go
-----3
UPDATE Reports
SET CloseDate = CONCAT(DATEPART(YEAR,GETDATE()),'-', DATEPART(MONTH,GETDATE()),'-', DATEPART(DAY,GETDATE()))
WHERE CloseDate IS NULL
go
-----4
DELETE Reports
WHERE StatusId = 4
go
-----5
SELECT Description,FORMAT(OpenDate, 'dd-MM-yyyy')
	FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY OpenDate ASC, Description ASC
go
-----6
SELECT r.Description, c.Name AS [CategoryName]
	FROM Reports AS r 
	JOIN Categories AS c ON r.CategoryId = c.Id
	ORDER BY r.Description,c.Name
go
-----7
SELECT TOP(5) c.Name, COUNT(r.Id) AS ReportsNumber
	FROM Reports as r
	JOIN Categories AS c ON r.CategoryId = c.Id
	GROUP BY c.Name
	ORDER BY ReportsNumber DESC,c.Name 
go
-----8
SELECT u.Username, c.Name AS [CategoryName]
	FROM Reports as r 
	JOIN Users AS u ON r.UserId = u.Id
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE CONCAT(DATEPART(MONTH, r.OpenDate),'-',DATEPART(DAY,r.OpenDate)) = CONCAT(DATEPART(MONTH, u.Birthdate),'-',DATEPART(DAY,u.Birthdate))
	ORDER BY u.Username,c.Name
go
-----9
SELECT CONCAT(e.FirstName, ' ',e.LastName) AS [FullName], COUNT(DISTINCT u.Id) AS [UsersCount]
	FROM Employees AS e
	LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
	LEFT JOIN Users as u ON r.UserId = u.Id
	GROUP BY e.FirstName,e.LastName
	ORDER BY UsersCount DESC, FullName
-----10
		SELECT IIF(CONCAT(e.FirstName, ' ', e.LastName) = '', 'None',  CONCAT(e.FirstName, ' ', e.LastName)) AS [Employee],
       IIF(d.Name IS NULL, 'None', d.Name) AS [Department],
					   c.Name AS Category,
					   r.Description AS Description,
					   FORMAT(r.OpenDate,'dd.MM.yyyy') AS OpenDate,
					   s.Label AS Status,
					    IIF(u.Name IS NULL, 'None', u.Name) AS [User]
		FROM Reports AS r
		LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
		LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
		LEFT JOIN Categories as c ON c.Id = r.CategoryId
		LEFT JOIN Status AS s ON r.StatusId=s.Id
		LEFT JOIN Users AS u ON r.UserId = u.Id
ORDER BY e.FirstName DESC, e.LastName DESC, d.Name, c.Name, r.Description, r.OpenDate, s.Id, u.Id
-----11
go
CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS 
BEGIN
	IF(@StartDate IS NULL) RETURN 0
	IF(@EndDate IS NULL) RETURN 0

	DECLARE @diff INT = DATEDIFF(HOUR,@StartDate,@EndDate)

return @diff
END
go

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports
-----12
go
CREATE OR ALTER PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN 
	 DECLARE @departmetnFromCategories INT = (SELECT DepartmentId
		FROM Reports as r
		JOIN Categories AS c ON r.CategoryId = c.Id
		WHERE r.Id = @ReportId)

		DECLARE @employeeDepartment INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)
		
		IF (@employeeDepartment != @departmetnFromCategories) THROW 50001, 'Employee doesn''t belong to the appropriate department!',1

		UPDATE Reports
			SET EmployeeId = @EmployeeId
			WHERE Id = @ReportId
END

EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2