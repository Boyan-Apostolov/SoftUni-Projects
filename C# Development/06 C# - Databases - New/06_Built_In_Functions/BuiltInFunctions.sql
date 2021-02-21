SELECT *, CONCAT(FirstName, ' ', MiddleName, LastName) FROM Employees

SELECT *, CONCAT_WS(' ',FirstName, MiddleName, LastName) FROM Employees

SELECT *, SUBSTRING(FirstName, 1, 1) FROM Employees

SELECT TOP(300) SUBSTRING(Value, 1, 100)+'...' FROM Demo

SELECT REPLACE('SoftUni', 'Soft', 'Hard')

SELECT LTRIM('       Bobby')
SELECT RTRIM('Bobby		')
SELECT TRIM('       Bobby			')

SELECT LEN('Bobby')

SELECT LEN('Bobby'), DATALENGTH(N'Боби'), N'Боби'

SELECT LEFT('Bobby',2)

SELECT RIGHT('Bobby',2)

SELECT LOWER('Bobby')

SELECT UPPER('Bobby')

SELECT REVERSE('Bobby')

SELECT REPLICATE('Bobby ', 5)

SELECT FORMAT(0.15,'p')

SELECT FORMAT(GETDATE(), 'dd MMMM yyyy', 'ru-RU')

SELECT FORMAT(1.123456789,'F2')

SELECT FORMAT(102.45, 'c', 'bg-BG')

SELECT value FROM string_split('Bobby1 Bobby2', ' ')

SELECT *,
	LEFT(PaymentNumber, 6)+REPLICATE('*',LEN(PaymentNumber) -6) AS [PaymentNumber]
	FROM Customers

SELECT CHARINDEX('am','I am Bobby Apotolov')
SELECT STUFF('I am Boyan', 6,0,'NOT')

SELECT 2 + 3 

SELECT Id,  A * H/ 2.0 AS Area 
	FROM Triangles2

SELECT PI()

SELECT ABS(-132)

SELECT SQRT(144)

SELECT SQRT(SQUARE(X1-X2) + SQUARE(Y1-Y2)) FROM Lines

SELECT ROUND(1.21345678,2) + 0.2

SELECT FLOOR(1.12467)

SELECT CEILING(1.12467)

SELECT CEILING(1.0 * Quantity / (BoxCapacity*PalletCapacity)) AS [Number of Pallets]
	FROM Products

SELECT SIGN(-34)
SELECT SIGN(0)
SELECT SIGN(34)

SELECT RAND(), RAND(), RAND(), RAND(), RAND(), RAND() 

SELECT DATEPART(MONTH,StartDate) FROM Projects

SELECT 
	DATEPART(QUARTER,StartDate) AS Quarter,
	DATEPART(MONTH,StartDate) AS Month,
	DATEPART(YEAR,StartDate) AS Year,
	DATEPART(DAY,StartDate) AS Day
	FROM Projects

SELECT
	StartDate,EndDate,
	DATEDIFF(QUARTER,StartDate,EndDate) 
	FROM Projects

SELECT DATENAME(WEEKDAY,StartDate) FROM Projects

SELECT DATEADD(hour,10,StartDate) FROM Projects

UPDATE Projects SET StartDate = DATEADD(minute,5,StartDate)

SELECT GETDATE()

SELECT EOMONTH(GETDATE())

SELECT CAST(1.2 AS INT)

SELECT CONVERT(INT, 1.2)

SELECT ISNULL(MiddleName, '_') FROM Employees

SELECT COALESCE(NULL, 5, NULL, 7, 8, NULL)

SELECT * FROM Projects 
	ORDER BY StartDate
	OFFSET 11 ROWS
	FETCH NEXT 1000 ROWS ONLY

SELECT *, ROW_NUMBER() OVER (ORDER BY Salary DESC) AS RowNumber
		, RANK() OVER (ORDER BY Salary DESC) AS Rank
		, DENSE_RANK() OVER (ORDER BY Salary DESC) AS DenseRank
		, NTILE(10) OVER (ORDER BY Salary DESC) AS GroupNo
	FROM Employees
	ORDER BY Salary DESC

SELECT * FROM Employees WHERE JobTitle LIKE '%Chief%'

SELECT * FROM Employees WHERE JobTitle LIKE '[EFR]%Manager'