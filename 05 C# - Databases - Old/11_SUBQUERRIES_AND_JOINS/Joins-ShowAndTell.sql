SELECT * FROM Employees AS e
JOIN Departments as d
ON e.DepartmentID = d.DepartmentID

SELECT * FROM Employees AS e
LEFT JOIN Departments as d
ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentID IS NULL

SELECT * FROM Employees AS e
RIGHT JOIN Departments as d
ON e.DepartmentID = d.DepartmentID
WHERE e.EmployeeID IS NULL

SELECT * FROM Employees AS e
JOIN Departments as d
ON e.DepartmentID > d.DepartmentID

SELECT TOP(50) e.FirstName,e.LastName,t.[Name] AS Town,a.AddressText FROM Employees AS e
LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
LEFT JOIN Towns AS t on a.TownID = t.TownID
ORDER BY e.FirstName,e.LastName 

SELECT e.EmployeeID,e.FirstName,e.LastName,d.[Name] AS DepartmentName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

SELECT e.FirstName,e.LastName,e.HireDate,d.[Name] AS DeptName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID =d.DepartmentID
AND d.[Name] IN ('Sales', 'Finance')
WHERE e.HireDate > '1999-01-01'
ORDER BY e.HireDate

SELECT TOP(50) e.EmployeeID, CONCAT(e.FirstName,' ',e.LastName) AS EmployeeName,CONCAT(m.FirstName,' ',m.LastName) AS ManagerName, d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID


SELECT MIN(dt.AverageSalary) AS MinAverageSalary FROM
(SELECT AVG(Salary) AS AverageSalary FROM Employees 
GROUP BY DepartmentID) AS dt
