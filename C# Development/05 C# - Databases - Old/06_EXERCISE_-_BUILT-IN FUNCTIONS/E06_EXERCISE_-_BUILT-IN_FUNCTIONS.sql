USE SoftUni3

--1
SELECT FirstName,LastName 
FROM Employees
WHERE FirstName LIKE 'SA%'

--2
SELECT FirstName,LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR,HireDate) BETWEEN 1995 AND 2005

--4
SELECT FirstName, LastName 
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--5
SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name]

--6
SELECT TownID,[Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

--7
SELECT TownID,[Name] FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

--8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,LastName FROM Employees 
WHERE DATEPART(YEAR,HireDate) > 2000

SELECT * FROM V_EmployeesHiredAfter2000
--9
SELECT FirstName,LastName FROM Employees
WHERE LEN(LastName) = 5

--Rank Employees By Salary
SELECT EmployeeId,FirstName,LastName,Salary, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--Rank Employees By Salary Then Find Employees with Rank 2*
SELECT * FROM (SELECT EmployeeId,FirstName,LastName,Salary, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000) AS temp
WHERE temp.[Rank] = 2
ORDER BY Salary DESC

--10
USE [Geography]

SELECT CountryName,IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--11
SELECT p.PeakName,r.RiverName, LOWER(CONCAT(LEFT(p.PeakName,LEN(p.PeakName)-1),r.RiverName)) AS [Mix] FROM Peaks AS p, Rivers AS r
WHERE RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
ORDER BY [Mix]

--12
USE Diablo

SELECT TOP(50) [Name],FORMAT([Start],'yyyy-MM-dd') FROM Games
WHERE DATEPART(YEAR,[Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

--13
SELECT [Username], RIGHT(Email, LEN(Email) - CHARINDEX('@', email)) [Email Provider] FROM Users
ORDER BY [Email Provider],[Username]

--14
SELECT [Username], [IpAddress] FROM Users
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

--15
SELECT [Name] AS [Game],
CASE
WHEN DATEPART(HOUR,[Start]) BETWEEN 0 AND 11 THEN 'Morning'
WHEN DATEPART(HOUR,[Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
ELSE 'Evening'
END AS [Part of the Day],
CASE
WHEN Duration <= 3  THEN 'Extra Short'
WHEN Duration BETWEEN 4 AND 6  THEN 'Short'
WHEN Duration > 3  THEN 'Long'
WHEN Duration IS NULL THEN 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY [Game],[Duration],[Part of the Day]

--16
USE Orders

SELECT product_name, order_date, 
DATEADD(DAY, 3, order_date) AS [pay_due],
DATEADD(MONTH, 1, order_date) AS [deliver_due]
FROM Orders;


