SELECT *
	FROM Addresses AS a
	JOIN Towns AS t  ON a.TownID = t.TownID

SELECT *
	FROM Addresses AS a
	LEFT JOIN Towns AS t  ON a.TownID = t.TownID

SELECT *
	FROM Addresses AS a
	RIGHT JOIN Towns AS t  ON a.TownID = t.TownID

SELECT *
	FROM Addresses AS a
	FULL OUTER JOIN Towns AS t  ON a.TownID = t.TownID

SELECT *
	FROM Addresses AS a
	CROSS JOIN Towns AS t
	
SELECT *
FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	LEFT JOIN Towns AS t  ON a.TownID = t.TownID

SELECT *
FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	RIGHT JOIN Towns AS t  ON a.TownID = t.TownID

SELECT * 
	FROM Employees
	CROSS JOIN Addresses

SELECT TOP(50) FirstName,LastName,t.Name,AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	ORDER BY FirstName,LastName

SELECT EmployeeID,FirstName,LastName, d.[Name] AS [DepartmentName]
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
	ORDER BY EmployeeID

SELECT e.FirstName,e.LastName,e.HireDate,d.[Name] AS [DeptName]
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE HireDate > '1999-01-01'
		AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
		--AND d.[Name] IN ('Sales', 'Finance')
	ORDER BY HireDate

SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName,
							 m.FirstName + ' ' + m.LastName AS ManagerName,
			   d.[Name] AS DepartmentName
	FROM Employees AS e
	LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID

SELECT e.FirstName,e.LastName, p.[Name]
	FROM EmployeesProjects AS ep
	JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID

	
SELECT e.FirstName,e.LastName,e.HireDate,
	(SELECT COUNT(*) FROM Employees AS e2 WHERE e2.FirstName = e.FirstName) AS OtherEmployeesWithTheSmaeName
	FROM Employees AS e
	WHERE e.DepartmentID IN (SELECT DepartmentID FROM Departments WHERE Name LIKE 'E%')

SELECT TOP(1) 
	(SELECT AVG(Salary)
		FROM Employees AS e 
			WHERE e.DepartmentID = d.DepartmentID) AS AverageSalary
	FROM Departments AS d
	WHERE (
		SELECT COUNT(*) 
			FROM Employees AS e2 
				WHERE e2.DepartmentID = d.DepartmentID) > 0
	ORDER BY AverageSalary

SELECT TOP(1) AVG(Salary) 
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY AVG(Salary) 

CREATE TABLE #Tmp(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100)
)
INSERT INTO #Tmp(Name) VALUES ('Bobby')
SELECT * FROM #Tmp