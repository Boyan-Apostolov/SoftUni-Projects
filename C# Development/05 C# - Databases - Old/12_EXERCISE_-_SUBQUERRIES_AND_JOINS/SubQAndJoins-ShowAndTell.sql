--1
Use SoftUni3

SELECT TOP(5) e.EmployeeID,e.JobTitle,a.AddressID,a.AddressText FROM Employees as e
JOIN Addresses as a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--2
SELECT TOP(50) e.FirstName,e.LastName,t.[Name] AS Town,a.AddressText FROM Employees AS e
LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
LEFT JOIN Towns AS t on a.TownID = t.TownID
ORDER BY e.FirstName,e.LastName 

--3
SELECT EmployeeID, FirstName, LastName, d.Name AS DepartmentName FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID

--4
SELECT TOP(5) e.EmployeeID,e.FirstName,e.Salary,d.[Name] FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID

--5
SELECT TOP(3) e.EmployeeID,e.FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

--6
SELECT e.FirstName,e.LastName,e.HireDate,d.[Name] AS DeptName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID =d.DepartmentID
AND d.[Name] IN ('Sales', 'Finance')
WHERE e.HireDate > '1999-01-01'
ORDER BY e.HireDate

--7
SELECT TOP(5) e.EmployeeID,e.FirstName, p.[Name] FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8
SELECT e.EmployeeID,e.FirstName,IIF(p.StartDate >= '01.01.2005',NULL, p.[Name]) FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID=ep.ProjectID
WHERE e.EmployeeID =24

--9
SELECT e.EmployeeID,e.FirstName,mng.EmployeeID,mng.FirstName FROM Employees AS e
JOIN Employees AS mng ON e.ManagerID = mng.EmployeeID
WHERE mng.EmployeeID IN (3,7)
ORDER BY e.FirstName

--10
SELECT TOP(50) emp.EmployeeID, CONCAT(emp.FirstName, ' ', emp.LastName) AS [EmployeeName],CONCAT(mng.FirstName, ' ', mng.LastName) AS [ManagerName],d.[Name] AS [DepartmentName] FROM Employees as emp
JOIN Employees AS mng ON mng.EmployeeID = emp.ManagerID
JOIN Departments AS d ON d.DepartmentID = emp.DepartmentID
ORDER BY emp.EmployeeID

--11
SELECT MIN(dt.AverageSalary) AS MinAverageSalary FROM
(SELECT AVG(Salary) AS AverageSalary FROM Employees 
GROUP BY DepartmentID) AS dt


go
--12
use Geography

SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation >2835
ORDER BY p.Elevation DESC

--13
SELECT CountryCode,COUNT(MountainId) 
FROM MountainsCountries
WHERE CountryCode IN ('US','RU','BG')
GROUP BY CountryCode

--14
SELECT TOP(5) c.CountryName,r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15
SELECT k.ContinentCode,k.CurrencyCode,k.CountOfCurrency FROM
(SELECT c.ContinentCode,c.CurrencyCode, COUNT(c.CurrencyCode) AS CountOfCurrency, DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS CurrenceRank
FROM Countries AS c
GROUP BY c.ContinentCode,c.CurrencyCode
HAVING COUNT(c.CurrencyCode) > 1) AS k
WHERE k.CurrenceRank = 1
ORDER BY k.ContinentCode

--16
SELECT COUNT(*) FROM Countries AS c
LEFT JOIN MountainsCountries as mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

--17
SELECT TOP(5) c.CountryName,MAX(p.Elevation) AS [HighestPeakElevation] ,MAX(r.[Length]) AS [LongestRiverLength] FROm Countries as c 
LEFT JOIn CountriesRivers AS cr on cr.CountryCode = c.CountryCode
LEFT JOIN Rivers as r on r.Id = cr.RiverId
LEFT JOIN MountainsCountries as mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC,[LongestRiverLength] DESC, c.CountryName

--18
SELECT TOP(5) k.CountryName,k.[Highest Peak Name],k.[Highest Peak Elevation],k.Mountain
FROM (
SELECT c.CountryName,
ISNULL(p.PeakName,'(no highest peak)') AS [Highest Peak Name],
ISNULL(p.Elevation, '0') AS [Highest Peak Elevation],
ISNULL(m.MountainRange,'(no mountain)') AS [Mountain],
DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [ElecationRank]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIn Peaks as p ON p.MountainId = m.Id
) AS k
WHERE k.ElecationRank = 1
ORDER BY k.CountryName,k.[Highest Peak Name] DESC

go