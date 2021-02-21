USE SoftUni3

SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName)
FROM Employees

SELECT CONCAT_WS('. ', SUBSTRING(FirstName,1,1),SUBSTRING(LastName,1,1),'') FROM Employees

SELECT REPLACE (MiddleName,'r', 'Peshov') FROM Employees

SELECT TRIM('            PESHO            ')

SELECT LEN('Pesho')

SELECT DATALENGTH('Pesho')

SELECT LEFT('Very long string',4)

SELECT RIGHT('Very long string',6)


USE Orders

SELECT CustomerID, FirstName, LastName,
CONCAT(SUBSTRING(PaymentNumber,1,6),REPLICATE('*',LEN(PaymentNumber-6)) AS PaymentNumber
FROM Customers

SELECT LOWER('BULGARIA')

SELECT UPPER('bulgaria')

SELECT REVERSE('racecar')

SELECT CHARINDEX('is', 'This is s long text')

SELECT STUFF('This is a bad idea',11,0,'very ')

SELECT FORMAT(67.23, 'C','bg-BG')

SELECT TRANSLATE('проба',N'абвгдезиклмнопрстуфх','abvgdeziklmnoprstufh')

SELECT PI()

SELECT ABS(-90)

SELECT SQUARE(12)

SELECT SQRT(144)

SELECT POWER(12,2)

SELECT ROUND(18.567,2)

SELECT FLOOR(1.9)

SELECT CEILING(1.1)

SELECT [Name], CEILING(CEILING(Quantity/BoxCapacity)/PalletCapacity) 
AS Pallets FROM Products

SELECT SIGN(50)

SELECT RAND()

SELECT DATEPART(day, '2019-01-21')

SELECT ProductName,YEAR(OrderDate), MONTH(OrderDate),DAY(OrderDate),DATEPART(QUARTER,OrderDatae)  FROM Orders

SELECT DATEDIFF(SECOND,'2019-01-21T21:11:48','2019-01-21T21:11:58')

SELECT DATENAME(weekday, GETDATE())

SELECT Hiredate, DATEADD(YEAR,5,HireDate) FROM Employees

SELECT EOMONTH(GETDATE())

SELECT CONVERT(date,'2019-01-21')

SELECT COALESCE(NULL,NULL,NULL,'FirstValue',NULL,NULL,'SecondValue')

SELECT EmployeeID FROM Employees ORDER BY EmployeeID OFFSET 10 ROWS FETCH NEXT 5 ROWS ONLY

SELECT EmployeeID,FirstName, DENSE_RANK() OVER (ORDER BY FirstName) FROM Employees

SELECT EmployeeID,FirstName FROM Employees
WHERE FirstName LIKE 'And[yr]%'