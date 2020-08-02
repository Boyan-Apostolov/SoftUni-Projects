CREATE DATABASE Airport

USE Airport

--DDL BEGIN
GO
CREATE TABLE Planes(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)

CREATE TABLE Flights(
Id INT PRIMARY KEY IDENTITY,
DepartureTime DATETIME2,
ArrivalTime DATETIME2,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
Address VARCHAR(30) NOT NULL,
PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
Id INT PRIMARY KEY IDENTITY,
LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id)
)

CREATE TABLE Tickets(
Id INT PRIMARY KEY IDENTITY,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightID INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price DECIMAL(18,2) NOT NULL
)
--DDL END
GO

--INSERT 
GO
INSERT INTO Planes([Name], Seats,Range) VALUES
('Airbus 336',112,5132),
('Airbus 330',432,5325),
('Boeing 369',231,2355),
('Stelt 297',254,2143),
('Boeing 338',165,5111),
('Airbus 558',387,1342),
('Boeing 128',345,5541)

INSERT INTO LuggageTypes([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')
--End Of INSERT
GO

--UPDATE
GO
UPDATE Tickets
SET Price *=1.13
WHERE FlightID IN 
(
SELECT [Id] FROM Flights WHERE Destination = 'Carlsbad'
)

--END OF UPDATE
GO

--DELETE
GO
DELETE FROM Tickets
WHERE FlightID IN
(
SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim'
)

DELETE FROM Flights WHERE Destination = 'Ayn Halagim'

--END OF DELETE
GO

--THE 'TR' PLANES
GO
SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id,[Name],Seats,[Range]
--END OF 'TR' PLANES
GO

--FLIGHT PROFITS
GO
SELECT f.Id as [FlightId], SUM(t.Price) AS [Price]
FROM Flights as f
JOIN Tickets as t
ON t.FlightID = f.Id
GROUP BY f.Id
ORDER BY [Price] DESC, [FlightId]
--END OF FLIGHT PROFITS
GO

--PASSENGER TRIPS
GO
SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
	f.Origin,
	f.Destination
FROM Passengers AS p
JOIN Tickets AS t
ON t.PassengerId =p.Id
JOIN Flights AS f
ON t.FlightID = f.Id
ORDER BY [Full Name],f.Origin,f.Destination
--END OF PASSENGER TRIPS
GO

--NON ADVENTUROUS PEOPLE
GO
SELECT FirstName AS [First Name],LastName AS [Last Name],Age
FROM Passengers AS p
LEFT JOIN Tickets AS t
ON t.PassengerId = p.Id
WHERE t.Id IS NULL
ORDER BY Age DESC,[First Name],[Last Name]
--END OF ADVENTUROUS PEOPLE
GO

--FULL INFO
GO
SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
	   pl.Name AS [Plane Name],
	   CONCAT(f.Origin,' - ',f.Destination ) AS [Trip],
	   lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets as t
ON t.PassengerId = p.Id
JOIN Flights AS f
ON t.FlightID = f.Id
JOIN Planes AS pl
ON f.PlaneId = pl.Id
JOIN Luggages AS l
ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt
ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name],[Plane Name],f.Origin,f.Destination,[Luggage Type]
--END OF FULL INVO
GO

--PSP
GO
SELECT p.[Name], p.Seats,COUNT(t.Id) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f
ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t
ON t.FlightID = f.Id
GROUP BY p.[Name],p.Seats
ORDER BY [Passengers Count] DESC, p.[Name],p.Seats

--END OF PSP
GO

--VACATION
GO
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50),@destination VARCHAR(50),@peopleCount INT)
RETURNS VARCHAR(500)
AS
BEGIN
	IF(@peopleCount <= 0)
	BEGIN
	RETURN 'Invalid people count!'
	END

	DECLARE @flightId INT = (SELECT TOP(1) Id FROM Flights WHERE Origin = @origin AND Destination = @destination)

	IF (@flightId IS NULL)
	BEGIN 
	RETURN 'Invalid flight!'
	END

	DECLARE @pricePerPerson DECIMAL(18,2) = (SELECT TOP(1) Price FROM Tickets WHERE FlightID = @flightId)

	DECLARE @totalPrice DECIMAL(24,2) = @pricePerPerson * @peopleCount

	RETURN CONCAT('Total price ', @totalPrice)
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)
--END OF VACATION
GO

--WRONG DATA
GO
CREATE PROC usp_CancelFlights
AS
BEGIN
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = null
	WHERE DATEDIFF(SECOND,DepartureTime,ArrivalTime) > 0
END

EXEC usp_CancelFlights
--END OF WRONG DATA
GO