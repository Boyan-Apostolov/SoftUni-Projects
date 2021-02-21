CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	Range INT NOT NULL
)


CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT NOT NULL REFERENCES Planes(Id)
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] NVARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
	FlightId INT NOT NULL FOREIGN KEY REFERENCES Flights(Id),
	LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
	Price DECIMAL (18,2) NOT NULL
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

-----
SELECT * FROM Tickets AS t
	JOIN Flights AS f ON t.FlightId = f.Id
	WHERE f.Destination = 'Carlsbad'

	UPDATE Tickets 
	SET Price = Price + Price * 0.13
	WHERE Id = 6

-----
DELETE Tickets WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE Flights
WHERE Destination = 'Ayn Halagim'

-----
SELECT Origin,Destination 
	FROM Flights
	ORDER BY Origin,Destination

-----
SELECT *
	FROM Planes
	WHERE Name LIKE '%tr%'
	ORDER BY id,name,Seats,Range

-----
SELECT f.Id as [FlightId], SUM(t.Price) AS [Price] 
	FROM Flights as f
	JOIN Tickets as t ON t.FlightId = f.Id
	GROUP BY f.Id
	ORDER BY [Price] DESC,[FlightId] ASC

-----
SELECT TOP(10) p.FirstName,p.LastName, t.Price
	FROM Passengers as p
	JOIN Tickets as t ON p.Id = t.PassengerId
	ORDER BY t.Price DESC,p.FirstName ASC, p.LastName ASC

-----
SELECT lt.Type,COUNT(lt.Id) AS MostUsedLuggage
	FROM Luggages AS l 
	JOIN LuggageTypes as lt ON lt.Id = l.LuggageTypeId
	GROUP BY lt.Type
	ORDER BY [MostUsedLuggage] DESC,lt.Type ASC

-----
SELECT CONCAT(p.FirstName,' ',p.LastName)AS [Full Name],
	   f.Origin,f.Destination
	FROM Passengers as p
	JOIN Tickets AS t ON p.Id = t.PassengerId 
	JOIN Flights AS f ON f.Id = t.FlightId
	ORDER BY [Full Name] ASC,Origin ASC,Destination ASC

-----
SELECT p.FirstName,p.LastName,p.Age
	FROM Passengers as p
	LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
	WHERE t.Id IS NULL
	ORDER BY Age DESC,FirstName,LastName

-----
SELECT PassportId,Address
	FROM Passengers as p
	LEFT JOIN Luggages As l ON l.PassengerId = p.Id
	WHERE l.Id IS NULL
	ORDER BY PassportId,Address

-----
SELECT p.FirstName,p.LastName, COUNT(t.Id) AS [Total Trips] 
	FROM Passengers AS p 
	LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
	GROUP BY p.FirstName,p.LastName
	ORDER BY [Total Trips] DESC,FirstName ASC,LastName ASC

-----
SELECT CONCAT(p.FirstName,' ',p.LastName)AS [Full Name],
       pl.[Name] as [Plane Name],
	   CONCAT(f.Origin,' - ',f.Destination) AS [Trip],
	   lt.Type AS [Luggage Type]
	FROM Passengers AS p 
	JOIN Tickets AS t ON t.PassengerId = p.Id
	JOIN Flights AS f ON f.Id = t.FlightId
	JOIN Planes AS pl ON f.PlaneId = pl.Id
	JOIN Luggages AS l ON t.LuggageId = l.Id
	JOIN LuggageTypes as lt ON l.LuggageTypeId = lt.Id
	ORDER BY [Full Name],pl.Name,Origin,Destination,lt.Type

-----
SELECT k.firstname,k.lastname,k.dest,k.price FROM(
SELECT p.FirstName as firstname,p.LastName as lastname,f.Destination as dest,t.Price as price, DENSE_RANK() OVER(PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) As PriceRank
	FROM Passengers as p
	JOIN Tickets as t ON p.Id = t.PassengerId
	JOIN Flights AS f ON t.FlightId = f.Id
	) as k
WHERE k.PriceRank = 1
ORDER BY k.Price DESC,firstname ASC, k.lastname ASC,k.dest ASC

-----
SELECT f.Destination, COUNT(t.Id) AS FliesCount
	FROM Tickets as t
	RIGHT JOIN Flights as f ON t.FlightId = f.Id
	GROUP BY f.Destination
	ORDER BY FliesCount DESC,f.Destination

-----
SELECT p.Name,p.Seats,COUNT(t.PassengerId) AS [Passengers Count]
	FROM Planes as p
	LEFT JOIN Flights as f ON p.Id = f.PlaneId
	LEFT JOIN Tickets as t ON t.FlightId = f.Id
	GROUP BY p.Name,p.Seats
	ORDER BY [Passengers Count] DESC,p.Name,p.Seats

-----
go
CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(30), @destination NVARCHAR(30), @peopleCount INT)
RETURNS NVARCHAR(100)
AS
BEGIN 
	IF (@peopleCount <= 0) RETURN ('Invalid people count!')

	DECLARE @flightId INT = (SELECT Id FROM Flights WHERE @origin = Origin AND @destination = Destination);

	IF(@flightId IS NULL) RETURN ('Invalid flight!');

	DECLARE @pricePerPerson DECIMAL(18,2) = (SELECT Price FROM Tickets WHERE FlightId = @flightId);

	DECLARE @totalPrice DECIMAL(18,2) = @peopleCount * @pricePerPerson;

RETURN 'Total price '+ CAST(@totalPrice AS nvarchar(50))
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

go

-----
CREATE PROC usp_CancelFlights
AS
BEGIN
UPDATE Flights SET DepartureTime = null, ArrivalTime = null  WHERE ArrivalTime > DepartureTime
END

EXEC usp_CancelFlights
