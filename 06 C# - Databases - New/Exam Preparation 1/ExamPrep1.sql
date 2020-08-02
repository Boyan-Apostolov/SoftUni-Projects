CREATE DATABASE Airport2
go

USE Airport2
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
	PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId iNT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15,2) NOT NULL
)
-----

INSERT INTO Planes(Name,Seats,Range) VALUES
('Airbus 336'	,112	,5132),
('Airbus 330'	,432	,5325),
('Boeing 369'	,231	,2355),
('Stelt 297'	,254	,2143),
('Boeing 338'	,165	,5111),
('Airbus 558'	,387	,1342),
('Boeing 128'	,345	,5541)

INSERT INTO LuggageTypes(Type) VALUES
('Crossbody Bag'),('School Backpack'),('Shoulder Bag')

-----3
UPDATE Tickets
SET Price += Price * 0.13
WHERE FlightId IN 
	(SELECT Id
		FROM Flights
		WHERE Destination = 'Carlsbad')

---4
select Id froM Flights WHERE Destination = 'Ayn Halagim'

DELETE FROM Tickets
	WHERE FlightId IN (select Id froM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights	
	WHERE Destination = 'Ayn Halagim'

---5
SELECT *
	FROM Planes
	WHERE Name LIKE '%tr%'
	ORDER BY id,Name,Seats,Range

---6
SELECT FlightId, SUM(Price) AS [Total Price]
	FROM Tickets as t
	JOIN Flights AS f ON t.FlightId = f.Id
	GROUP BY FlightId
	ORDER BY [Total Price] DESC,FlightId

----7
SELECT CONCAT(p.FirstName, ' ',p.LastName) AS [Full Name],
	   f.Origin as Origin,
	   f.Destination AS Destination
	FROM Passengers as p
	JOIN Tickets as t ON t.PassengerId = p.Id
	JOIN Flights as f ON t.FlightId = f.Id
	ORDER BY [Full Name],Origin,Destination

-----8
SELECT p.FirstName,p.LastName,p.Age 
	FROM Passengers as p
	LEFT JOIN Tickets as t ON p.Id = t.PassengerId
	WHERE t.Id IS NULL
	ORDER BY p.Age desc, p.FirstName,p.LastName

-----9
SELECT CONCAT(p.FirstName, ' ',p.LastName) AS [Full Name],
	   pl.Name as [Plane Name],
	   CONCAT(f.Origin,' - ',f.Destination) AS Trip,
	   lt.Type AS [Luggage Type]
	FROM Passengers as p
	JOIN Tickets as t ON t.PassengerId = p.Id
	JOIN Flights as f ON t.FlightId = f.Id
	JOIN Planes as pl ON f.PlaneId = pl.Id
	JOIN Luggages as l ON t.LuggageId = l.Id
	JOIN LuggageTypes as lt ON l.LuggageTypeId = lt.Id
	ORDER BY [Full Name],pl.Name,f.Origin,f.Destination,lt.Type

-----10
SELECT pl.Name,pl.Seats, COUNT(t.PassengerId) AS [Passengers Count]
	FROM Planes AS pl
	LEFT JOIN Flights as f ON pl.Id = f.PlaneId
	LEFT JOIN Tickets as t ON t.FlightId = f.Id
	GROUP BY pl.Name,pl.Seats
	ORDER BY [Passengers Count] DESC,pl.Name,pl.Seats

-----11
go
CREATE OR ALTER FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(70)
AS 
BEGIN
	IF(@peopleCount <= 0 OR @peopleCount IS NULL) RETURN ('Invalid people count!')

	DECLARE @flightId INT = (SELECT TOP(1) Id FROM Flights WHERE Origin = @origin AND Destination = @destination )

	IF(@flightId IS NULL) RETURN ('Invalid flight!')

	DECLARE @pricePerTicket DECIMAL(15,2) = (SELECT Price FROM Tickets as t WHERE t.FlightId = @flightId)

	DECLARE @totalPrice DECIMAL(24,2) = @pricePerTicket * @peopleCount

	RETURN CONCAT('Total price ', @totalPrice)
END
go

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

------12
go
CREATE OR ALTER PROC usp_CancelFlights
AS
BEGIN
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL
	WHERE DATEDIFF(SECOND,ArrivalTime,DepartureTime) < 0
END
go

EXEC usp_CancelFlights