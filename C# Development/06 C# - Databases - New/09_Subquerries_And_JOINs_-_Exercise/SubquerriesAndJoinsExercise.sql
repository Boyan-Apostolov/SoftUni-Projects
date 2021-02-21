--1
SELECT TOP(5) e.EmployeeID,e.JobTitle,a.AddressID,a.AddressText 
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	ORDER BY a.AddressID

--2
SELECT TOP(50) e.FirstName, e.LastName,t.[Name] as Town, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	ORDER BY e.FirstName,e.LastName

--3
SELECT e.EmployeeID,e.FirstName, e.LastName,d.Name
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY EmployeeID

--4
SELECT TOP(5) e.EmployeeID,e.FirstName,e.Salary,d.Name
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY d.DepartmentID

--5
SELECT TOP(3) e.EmployeeID,e.FirstName
	FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
	WHERE ep.EmployeeID IS NULL
	ORDER BY e.DepartmentID

--6
SELECT e.FirstName,e.LastName,e.HireDate,d.Name AS DeptName 
	FROM Employees AS e
	JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '01-01-1999' AND  d.Name IN ('Sales', 'Finance')
	ORDER BY e.HireDate ASC

--7
SELECT TOP(5) e.EmployeeID,e.FirstName,p.Name AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID 
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE p.StartDate > '2002-03-18' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID

--8
SELECT TOP(5) e.EmployeeID,e.FirstName,
	CASE
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS ProjectName
	FROM Employees AS e
	JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID 
	JOIN Projects AS p ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--9
SELECT e.EmployeeID,e.FirstName,m.EmployeeID,m.FirstName AS ManagerName
	FROM Employees AS e
	JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	WHERE m.EmployeeID IN (3,7)
	ORDER BY e.EmployeeID ASC

--10
SELECT TOP(50) e.EmployeeID
	,e.FirstName+' '+e.LastName AS EmployeeName
	, m.FirstName+' '+m.LastName AS ManagerName
	,d.Name AS DepartmentName
		FROM Employees AS e
		JOIN Employees AS m ON e.ManagerID = m.EmployeeID
		JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
		ORDER BY e.EmployeeID

--11
SELECT MIN(AverageSalary) AS MinAverageSalary
			FROM
			(SELECT AVG(Salary) AS AverageSalary
				FROM Employees
				GROUP BY DepartmentID 
			) as temp

--SELECT TOP(1) AVG(Salary) AS MinAverageSalary
--				FROM Employees
--				GROUP BY DepartmentID 
--	ORDER BY MinAverageSalary

--12
SELECT c.CountryCode, m.MountainRange,p.PeakName,p.Elevation 
	FROM Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains AS m ON mc.MountainId = m.Id
	JOIN Peaks AS p ON p.MountainId = m.Id
	WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC

--13
SELECT CountryCode, COUNT(MountainId) AS MountainRanges
	FROM MountainsCountries
	WHERE CountryCode IN ('BG', 'RU', 'US')
	GROUP BY CountryCode

--14
SELECT TOP(5) c.CountryName, r.RiverName
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName ASC

--15
SELECT rankedCurrencies.ContinentCode, rankedCurrencies.CurrencyCode, rankedCurrencies.Count
FROM (
SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS [Count], DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [rank] 
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode) AS rankedCurrencies
WHERE rankedCurrencies.rank = 1 and rankedCurrencies.Count > 1

--16
SELECT COUNT(*) AS [Count]
	FROM MountainsCountries AS mc
	FULL OUTER JOIN Countries AS c ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL

SELECT * FROM Countries

--17
SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS [Highest Peak Elevation], MAX(r.Length) AS [Longest River Length]
	FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	GROUP BY c.CountryName
	ORDER BY [Highest Peak Elevation] DESC, [Longest River Length] DESC, c.CountryName ASC

 --18
SELECT TOP(5) Country
,CASE
	WHEN PeakName IS NULL THEN '(no highest peak)'
	ELSE PeakName
	END AS [Highest Peak Name]

,CASE
	WHEN Elevation IS NULL THEN 0
	ELSE Elevation
	END AS [Highest Peak Elevation]

,CASE
	WHEN MountainRange IS NULL THEN '(no mountain)'
	ELSE MountainRange
	END AS [Mountain]
	FROM (
		SELECT *,
			DENSE_RANK() OVER (PARTITION BY [Country] ORDER BY [Elevation] DESC) AS [PeakRank]
			FROM (
				SELECT CountryName AS [Country], p.PeakName,p.Elevation,m.MountainRange 
				FROM Countries AS c
				LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
				LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
				LEFT JOIN Peaks AS p ON p.MountainId = m.Id) AS [FullInfoQuerry]
		) AS [PeakRankingsQuerry]
		WHERE PeakRank = 1
		ORDER BY Country ASC, [Highest Peak Name] ASC
