--2
SELECT *
	FROM Departments
go

--3
SELECT [Name]
	FROM Departments
go

--4
SELECT FirstName, LastName, Salary
	FROM Employees
go

--5
SELECT FirstName,MiddleName,LastName
	FROM Employees
go

--6
SELECT CONCAT(FirstName, '.', LastName, '@softuni.bg')
	FROM Employees
go

--7
SELECT DISTINCT Salary
	FROM Employees
go

--8
SELECT *
	FROM Employees
	WHERE JobTitle = 'Sales Representative'
go

--9
SELECT FirstName,LastName,JobTitle
	FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000
go

--10
SELECT CONCAT(FirstName,' ',MiddleName,' ',LastName) AS [Full Name]
	FROM Employees
	WHERE Salary IN (25000,14000,12500,23600)
go

--11
SELECT FirstName, LastName
	FROM Employees
	WHERE ManagerID IS NULL
go

--12
SELECT FirstName,Lastname,Salary
	FROM Employees
	WHERE Salary > 50000
	ORDER BY Salary DESC
go

--13
SELECT TOP(5) FirstName,LastName
	FROM Employees
	ORDER BY Salary DESC
go

--14
SELECT FirstName,LastName
	FROM Employees
	WHERE DepartmentID != 4
go

--15
SELECT *
	FROM Employees
	ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName
go

--16
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, Lastname, Salary
	FROM Employees
go

--17
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name],JobTitle
	FROM Employees
go

--18
SELECT DISTINCT JobTitle
	FROM Employees
go

--19
SELECT TOP(10)* 
FROM Projects
ORDER BY StartDate ASC, [Name] ASC
go

--20
SELECT TOP(7) FirstName,LastName,HireDate
	FROM Employees
	ORDER BY HireDate DESC
go

--21
UPDATE Employees
	SET Salary = Salary * 1.12
	WHERE DepartmentID IN (1,2,4,11)

SELECT Salary
	FROM Employees
go

--22
SELECT PeakName
	FROM Peaks
	ORDER BY PeakName
go

--23
SELECT TOP(30) CountryName, [Population]
	FROM Countries
	WHERE ContinentCode = 'EU'
	ORDER BY [Population] DESC, CountryName
go

--24
SELECT CountryName,CountryCode,
CASE
WHEN CurrencyCode = 'EUR' THEN 'Euro'
ELSE 'Not Euro'
END AS [Currency] 
	FROM Countries
	ORDER BY CountryName ASC
go

--25
SELECT [Name]
	FROM Characters
	ORDER BY [Name]
go
