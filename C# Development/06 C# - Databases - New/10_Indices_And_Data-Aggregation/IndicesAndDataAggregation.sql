CREATE INDEX IX_Message_Price ON Messages(MsgPrice)

SELECT COUNT(*)DepartmentID
	FROM Employees
	GROUP BY DepartmentID


SELECT DepartmentID, MIN(Salary) 
	FROM Employees
	GROUP BY DepartmentID

SELECT COUNT(*)Firstname
	FROM Employees
	GROUP BY FirstName

SELECT DepartmentID,FirstName, COUNT(*)Firstname
	FROM Employees
	GROUP BY DepartmentID, FirstName

SELECT DISTINCT DepartmentID	
	FROM Employees

SELECT DepartmentID, COUNT(*), STRING_AGG(FirstName,' ')
FROM Employees
GROUP BY DepartmentID

SELECT DepartmentID, SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID ASC


SELECT d.Name, SUM(Salary) AS TotalSalary
	FROM Employees as e
	JOIN Departments as d ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name,e.DepartmentID
	ORDER BY d.Name
	
SELECT DepartmentId, 
	MAX(HireDate) AS LastHireDate,
	MAX(Salary) AS MaxSalary, MIN(Salary) AS MinSalary,
	MAX(Salary) - MIN(Salary) AS Diff,
	AVG(Salary) AS Average
	FROM Employees
	GROUP BY DepartmentID

SELECT DepartmentID, COUNT(*)
	FROM Employees e
	WHERE Salary > 100000
	GROUP BY DepartmentID

SELECT DepartmentID, COUNT(*), AVG(Salary)
	FROM Employees e
	GROUP BY DepartmentID
	HAVING AVG(Salary) < 15000 AND COUNT(*) < 100

SELECT DepartmentId,FirstName, STRING_AGG(LastName, ' ')
	FROM Employees
	GROUP BY DepartmentID,FirstName