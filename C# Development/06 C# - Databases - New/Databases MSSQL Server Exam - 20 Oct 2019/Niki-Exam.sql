CREATE DATABASE Service2
GO
USE Service2
GO

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Status(
	Id INT PRIMARY KEY IDENTITY,
	Label NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description NVARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

-----2
INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId) VALUES
('Marlo',	'O''Malley',	'1958-9-21',1),
('Niki	  ',' Stanaghan	','1969-11-26',	4),
('Ayrton	','Senna	','1960-03-21',	9),
('Ronnie	','Peterson	','1944-02-14',	9),
('Giovanna','	Amati	','1959-07-20',	5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId) VALUES
(1	,1	,'2017-04-13',		NULL	,'Stuck Road on Str.133			',6	,2),
(6	,3	,'2015-09-05',	'2015-12-06','Charity trail running			',3	,5),
(14	,2	,'2015-09-07',		NULL	,'Falling bricks on Str.58		',5	,2),
(4	,3	,'2017-07-03',	'2017-07-06','Cut off streetlight on Str.11	',1	,1)

-----3
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

-----4
DELETE Reports
WHERE StatusId = 4

-----5
SELECT Description, FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
	FROM Reports
	WHERE EmployeeId IS NULL
	ORDER BY Reports.OpenDate, Description

-----6
SELECT r.Description,c.Name
	FROM Reports AS r
	JOIN Categories AS c ON r.CategoryId = c.Id
	ORDER BY Description,Name

-----7
SELECT TOP(5) c.Name,COUNT(*) AS ReportsNumber
	FROM Reports AS r
	JOIN Categories AS c ON r.CategoryId = c.Id
	GROUP BY c.Name
	ORDER BY ReportsNumber DESC,c.Name

-----8
SELECT u.Username,c.Name
	FROM Reports AS r
	JOIN Users AS u ON r.UserId = u.Id
	JOIN Categories AS c ON r.CategoryId = c.Id
	WHERE DATEPART(MONTH,r.OpenDate) = DATEPART(MONTH,u.BirthDate) AND DATEPART(DAY,r.OpenDate) = DATEPART(DAY,u.BirthDate)
	ORDER BY u.Username,c.Name

-----9
SELECT FirstName+' '+LastName AS FullName,
	   (SELECT COUNT(DISTINCT UserId) FROM Reports WHERE EmployeeId = e.Id) AS UsersCount
	FROM Employees AS e
	ORDER BY UsersCount DESC, FullName ASC

-----10
SELECT ISNULL((e.FirstName+ ' '+e.LastName),'None') AS Employee,
	   ISNULL(d.Name,'None') AS Department,
	   ISNULL(c.Name,'None') AS Category,
	   r.Description,
	   FORMAT(r.OpenDate,'dd.MM.yyyy') AS OpenDate,
	   s.Label AS Status,
	   ISNULL(u.Name,'None') AS [User]
	FROM Reports AS r
	LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
	LEFT JOIN Categories AS c ON c.Id = r.CategoryId
	LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
	LEFT JOIN Status AS s ON r.StatusId = s.Id
	LEFT JOIN Users AS u ON u.Id = r.UserId
	ORDER BY FirstName DESC,LastName DESC,d.Name,c.Name,r.Description,r.OpenDate,s.Label,u.Name

-----11
go
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL) RETURN 0
	IF(@EndDate IS NULL) RETURN 0

	RETURN DATEDIFF(HOUR,@StartDate,@EndDate)
END

-----12
go
CREATE PROC usp_AssignEmplpoyeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @employeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE Id= @EmployeeId)
	DECLARE @reportDepartmetnID INT = (SELECT c.DepartmentId FROM Reports AS r JOIN Categories AS c ON c.Id = r.CategoryId WHERE r.Id = @ReportId)
	
	IF(@employeeDepartmentId != @reportDepartmetnID) THROW 50001 , 'Employee doesn''t belong to that department!', 1

UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE Id = @ReportId
END