SELECT *
FROM Employees
WHERE DepartmentID = 2 

SELECT e.DepartmentId, SUM(e.Salary)
FROM Employees e
GROUP BY e.DepartmentID 

SELECT DISTINCT DepartmentID FROM Employees

SELECT e.DepartmentID
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.DepartmentId, SUM(e.Salary) as Salary
FROM Employees e
GROUP BY e.DepartmentID 
ORDER BY e.DepartmentID


SELECT e.DepartmentId, COUNT(e.DepartmentID) AS NumberOfEmployees
FROM Employees e
GROUP BY e.DepartmentID 
ORDER BY e.DepartmentID

SELECT e.FirstName, e.LastName, d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID

SELECT e.DepartmentID, 
MIN(e.Salary) AS [MIN],
COUNT(e.Salary) AS [COUNT],
AVG(e.Salary) AS [AVG],
MAX(e.Salary) AS [MAX],
SUM(e.Salary) AS [SUM],
STRING_AGG(e.FirstName,', ')
FROM Employees e
GROUP BY e.DepartmentID
HAVING SUM(e.Salary) > 500000