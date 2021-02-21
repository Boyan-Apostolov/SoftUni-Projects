SELECT TownId, [Name] 
	FROM Towns

SELECT GETDATE()

SELECT * 
	FROM Towns
	WHERE LEFT([Name],1) = 'S'

SELECT [Name], LEN([Name]) AS Lenght, LEFT([Name],1) AS FirstLetter
	FROM Towns
	WHERE LEFT([Name],1) = 'S'

SELECT AddressText, [Name]
	FROM Addresses 
	JOIN Towns ON Addresses.TownID = Towns.TownID
	WHERE [Name] = 'Seattle'


SELECT a.AddressText, t.[Name]
	FROM Addresses AS a
	JOIN Towns AS t
	ON a.TownID = t.TownID
	WHERE [Name] = 'Seattle'

SELECT FirstName + ' ' + LastName AS [Full Name], JobTitle, Salary
	FROM Employees
	
SELECT DISTINCT
     JobTitle
	FROM Employees

SELECT DISTINCT
     JobTitle,EmployeeID
	FROM Employees


SELECT DISTINCT
     FirstName
	FROM Employees

SELECT COUNT(DISTINCT JobTitle)
	FirstName
	FROM Employees

SELECT JobTitle, COUNT(*)
	FROM Employees
	GROUP BY JobTitle

SELECT *
	FROM Employees
	WHERE Salary >= 1070

SELECT * 
	FROM Employees
	WHERE FirstName = 'Chris'

SELECT *
	FROM Employees
	WHERE FirstName LIKE '%ete%' --contains

SELECT *
	FROM Employees
	WHERE Salary != 1000

SELECT *
	FROM Employees
	WHERE Salary >= 1000
	AND Salary < 5000

SELECT *
	FROM Employees
	WHERE Salary BETWEEN 1000 AND 5000


SELECT *
	FROM Employees
	WHERE FirstName = 'Alice' OR LastName = 'Li' 

SELECT *
	FROM Employees
	WHERE DepartmentID IN (3, 6)

SELECT *
	FROM Employees
	WHERE MiddleName IS NULL

SELECT *
	FROM Employees
	ORDER BY Salary DESC

SELECT *
	FROM Employees
	ORDER BY FirstName
	
SELECT *
	FROM Employees
	ORDER BY FirstName, LastName

SELECT *
	FROM Employees
	--WHERE HireDate >= '2000-01-01' AND HireDate < '2001-01-01'
	WHERE YEAR(HireDate) = 2000

CREATE VIEW V_GetHireDateAndDayOfWeek AS
SELECT HireDate, DATENAME(dw,HireDate) AS [Day Of Week]
	FROM Employees

SELECT * FROM V_GetHireDateAndDayOfWeek

CREATE VIEW V_GetHighestPeak AS
SELECT TOP(1)*
	FROM Peaks
	ORDER BY Elevation DESC

INSERT INTO Towns VALUES (33, 'Plovdiv')

INSERT INTO Towns([Name]) VALUES
	('Varna'), ('Burgas'), ('Pleven')

INSERT INTO Employees(FirstName,LastName,JobTitle,DepartmentID,HireDate,Salary) VALUES
('Niki', 'Kostov', 'Trainer', 7, GETDATE(),10000),
('Stoyan', 'Shopov', 'Trainer', 1, GETDATE(),10000)

INSERT INTO Projects(Name,Description,StartDate)
SELECT 'New'+Name,Description, GETDATE() AS StartDate
FROM Projects

SELECT FirstName + ' '+ LastName AS FullName, Salary
	INTO Names
	FROM Employees

CREATE SEQUENCE seq_MyNumber
	AS INT
	START WITH 0
	INCREMENT BY 1001

SELECT NEXT VALUE FOR seq_MyNumber

DELETE FROM Names
	WHERE FullName LIKE 'R%'

UPDATE Names
	SET Salary = Salary + 1000
	WHERE FullName LIKE '%Niki%'

UPDATE Projects
	SET EndDate = GETDATE()
	WHERE [EndDate] IS NULL