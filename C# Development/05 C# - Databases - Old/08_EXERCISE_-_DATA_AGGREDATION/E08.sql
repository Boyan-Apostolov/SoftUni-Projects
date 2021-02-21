--1


--2
SELECT MAX(MagicWandSize) 
AS [LongestMagicWand]
FROM WizzardDeposits

--3
SELECT DepositGroup,MAX(MagicWandSize)
AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

--4
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize
)
--5


--6


--7
SELECT DepositGroup, SUM(DepositAmount )
FROM WizzardDeposits 
WHERE MagicWandCreator = 'Ollivander family'
Group BY DepositGroup 
HAVING SUM(DepositAmount) < 15000
ORDER BY [TotalSum] DESC

--8
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup DESC

--9
SELECT 
CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 0 AND 10 THEN '[31-40]'
WHEN Age BETWEEN 0 AND 10 THEN '[41-50]'
WHEN Age BETWEEN 0 AND 10 THEN '[51-60]'
ELSE '[61]+'
END AS [AgeGroup],
COUNT(*) AS [WizzardCount]
FROM WizzardDeposits
GROUP BY CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 0 AND 10 THEN '[31-40]'
WHEN Age BETWEEN 0 AND 10 THEN '[41-50]'
WHEN Age BETWEEN 0 AND 10 THEN '[51-60]'
ELSE '[61]+'

--10


--11


--12
SELECT SUM(Difference) AS SumDifference FROM (SELECT FirstName AS [HostWizard],
DepositAmount As [Host Wizzard Deposit],
LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizzard],
LEAD(DepositAmount) OVER (Order BY Id) AS [Guest Wizzard Deposit],
DepositAmount - LEAD(DepositAmount) OVER (Order BY Id) AS Difference
FROM WizzardDeposits) As DiffTable

--13


--14


--15
SELECT * INTO NewEmployeesTable FROM Employees
WHERE Salary > 30000

DELETE FROM NewEmployeesTable
WHERE ManagerID = 42

UPDATE NewEmployeesTable
SET Salary = 5000
WHERE DepartmentID =1

SELECT DepartmentID, AVG(Salary) AS [Average Salary] FROM NewEmployeesTable GROUP BY DepartmentID

--16


--17


--18
USE SoftUni3

SELECT DISTINCT DepartmentID, Salary AS [ThirdHighestSalary] 
FROM(
SELECT DepartmentID,Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary Desc )AS RANKING
FROM Employees) AS [RankTable]
WHERE RANKING = 3

--19

Select TOP(10) FirstName, LastName,DepartmentID FROM Employees as e1
WHERE Salary > (
SELECT AVG(Salary) AS [Avg Salary] FROM Employees as e2
WHERE e2.DepartmentID = e1.DepartmentID
GROUP BY DepartmentID 
)
ORDER BY e1.DepartmentID
