--1
SELECT COUNT(*) AS Count FROM WizzardDeposits

--2
SELECT TOP(1) MAX(MagicWandSize) AS LongestmagicWand 
	FROM WizzardDeposits
	GROUP BY MagicWandSize
	ORDER BY LongestmagicWand DESC
--3
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
	FROM WizzardDeposits
	GROUP BY DepositGroup

--4
SELECT TOP(2) AvgWandSizeQuerry.DepositGroup FROM (SELECT DepositGroup , AVG(MagicWandSize) AS AvgWandSize
	FROM WizzardDeposits
	GROUP BY DepositGroup) AS AvgWandSizeQuerry
	ORDER BY AvgWandSize

--5
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	GROUP BY DepositGroup

--6
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander Family'
	GROUP BY DepositGroup

--7
SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander Family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY TotalSum DESC

--8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
	FROM WizzardDeposits
	GROUP BY DepositGroup,MagicWandCreator
	ORDER BY MagicWandCreator, DepositGroup

--9
SELECT AgeGroup, COUNT(*) AS [WizzardsCount] FROM
(SELECT 
	CASE
		WHEN Age <= 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE'[61+]'
	END AS [AgeGroup],*
		FROM WizzardDeposits
	) AS [AgeGroupQuerry]
GROUP BY [AgeGroup]

--10
SELECT DISTINCT LEFT(FirstName,1) AS FirstLetter
	FROM WizzardDeposits
	WHERE DepositGroup = 'Troll Chest'
	GROUP BY FirstName
	ORDER BY FirstLetter

--11
SELECT DepositGroup,IsDepositExpired, AVG(DepositInterest) AS [AverageInterest]
	FROM WizzardDeposits
	WHERE DepositStartDate > '01/01/1985'
	GROUP BY DepositGroup,IsDepositExpired
	ORDER BY DepositGroup DESC, IsDepositExpired ASC

--12
SELECT SUM(processingQuerry.Differance) AS SumDifferance FROM
(SELECT
	FirstName AS [Host Wizzard],
	DepositAmount As [Host Wizzard Deposit],
	LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizzard],
	LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizzard Deposit],
	DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Differance]
	FROM WizzardDeposits ) as processingQuerry
	
--13
SELECT DepartmentID, SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

--14
SELECT DepartmentID, MIN(Salary) AS MinumumSalary
	FROM Employees
	WHERE DepartmentID IN (2,5,7) AND HireDate > '01/01/2000'
	GROUP BY DepartmentID

--15
SELECT * INTO EmployeesWithHIghSalaries
	FROM Employees
	WHERE Salary > 30000

DELETE FROM EmployeesWithHIghSalaries
WHERE ManagerID = 42

UPDATE EmployeesWithHIghSalaries
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) FROM EmployeesWithHIghSalaries
GROUP BY DepartmentID

--16
SELECT DepartmentID, MAX(Salary) AS MaxSalary
	FROM Employees
	GROUP BY DepartmentID
	--HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000
	HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

--17
SELECT COUNT(*)	AS Count
	FROM Employees
	WHERE ManagerID IS NULL

--18
SELECT DepartmentID, Salary AS [ThirdHighestSalary] FROM(
SELECT DepartmentID,Salary, 
	DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary dESC) AS [Salary Rank]
	FROM Employees
	GROUP BY DepartmentID,Salary
	) AS SalaryRankingsQuerry
WHERE [Salary Rank] = 3

--19
SELECT TOP(10) FirstName, LastName,DepartmentID
	FROM Employees as e1
	WHERE e1.Salary >
	(
	SELECT AVG(Salary) AS AverageSalary
	FROM Employees as e2
	WHERE e1.DepartmentID = e2.DepartmentID
	GROUP BY DepartmentID
	)
ORDER BY DepartmentID ASC

go
--17 Feb 2019 Exam DDL
CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(50) NOT NULL,
	Age TINYINT CHECK(Age >= 5 AND Age <= 100),
	[Address] NVARCHAR(50) ,
	Phone NCHAR(10)
)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL CHECK(Lessons>0)
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3,2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6)
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME2,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)

CREATE TABLE StudentsExams(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(3,2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6),
	PRIMARY KEY (StudentId,ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL.
	Address NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) Not NULL,
)

CREATE TABLE StudentsTeachers(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL
) 
go