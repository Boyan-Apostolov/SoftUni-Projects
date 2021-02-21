CREATE DATABASE TripService
GO
USE TripService
GO
-----1
CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15,2)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CONSTRAINT BookBeforeArrive CHECK(BookDate < ArrivalDate),
	CONSTRAINT ArriveBeforeReturn CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0),
	PRIMARY KEY(AccountId,TripId)
)

-----2
INSERT INTO Accounts(FirstName,MiddleName,LastName,CityId,BirthDate,Email) VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId,BookDate,ArrivalDate,ReturnDate,CancelDate) VALUES
( 101, '2015-04-12', '2015-04-14', '2015-04-20' ,'2015-02-02'),
( 102, '2015-07-07', '2015-07-15', '2015-07-22' ,'2015-04-29'),
( 103, '2013-07-17', '2013-07-23', '2013-07-24' ,NULL),
( 104, '2012-03-17', '2012-03-31', '2012-04-01' ,'2012-01-10'),
( 109, '2017-08-07', '2017-08-28', '2017-08-29' ,NULL)


-----3
UPDATE Rooms
SET Price = Price + Price * 0.14
WHERE HotelId IN (5,7,9)

-----4
DELETE AccountsTrips
WHERE AccountId = 47

-----5
SELECT a.FirstName,a.LastName,FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate, c.Name AS Hometown, a.Email
	FROM Accounts AS a
	JOIN Cities AS c ON c.Id = a.CityId
	WHERE Email LIKE 'e%'
	ORDER BY c.Name ASC

-----6
SELECT c.Name AS City, COUNT(h.Id) AS Hotels
	FROM Cities AS c
	JOIN Hotels as h ON h.CityId = c.Id
	GROUP BY c.Name
	ORDER BY Hotels DESC,c.Name

-----7
SELECT a.Id AS [AccountId],
	   CONCAT(a.FirstName, ' ',a.LastName) AS [FullName],
	   MAX(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS [ShortestTrip]
	FROM Accounts AS a
	JOIN AccountsTrips AS acct ON acct.AccountId = a.Id
	JOIN Trips AS t ON acct.TripId = t.Id
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
	GROUP BY a.Id,a.FirstName,a.LastName
	ORDER BY LongestTrip DESC,ShortestTrip ASC

-----8
SELECT TOP(10) c.Id,c.Name,c.CountryCode, COUNT(a.CityId) AS Account
	FROM Cities AS c
	JOIN Accounts AS a ON a.CityId = c.Id
	GROUP BY c.Id,c.CountryCode,c.Name
	ORDER BY Account DESC

-----9
SELECT a.Id,a.Email,c.Name AS [City] ,COUNT(*) AS [Trips]
	FROM Accounts AS a

	JOIN Cities AS c ON a.CityId = c.Id
	JOIN AccountsTrips AS ats ON ats.AccountId = a.Id
	JOIN Trips AS t ON ats.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	WHERE h.CityId = a.CityId
	GROUP BY a.Id,a.Email,c.Name
	ORDER BY Trips DESC,a.Id
	
-----10
go
SELECT t.Id, CONCAT(a.FirstName, ' ', COALESCE(a.MiddleName+ ' ',''), a.LastName) AS [Full Name], 


	(SELECT c.Name 
		FROM Accounts AS aa
		JOIN Cities AS c ON aa.CityId = c.Id
		WHERE aa.Id = a.Id
		) AS [From]

		,
	(SELECT c.Name 
		FROM Hotels AS h
		JOIN Cities AS c ON h.CityId = c.Id
		WHERE h.Id = r.HotelId
		) AS [To]
		,
		CASE
		WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' days')
	END AS [Duration]

	FROM Trips AS t
	JOIN AccountsTrips AS ats ON ats.TripId = t.Id
	JOIN Accounts AS a ON ats.AccountId = a.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	ORDER BY [Full Name],t.Id
	go

	--t.Id, CONCAT(aa.FirstName,' ',aa.MiddleName,' ', aa.LastName) AS [Full Name],
	   
	--CASE
	--	WHEN t.CancelDate IS NULL THEN 'Canceled'
	--	ELSE CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' days')
	--END AS [Duration]




-----11
go
CREATE FUNCTION udf_GetAvailableRoom(@HotelId int, @Date datetime2, @People int) 
RETURNS nvarchar(200)
AS
BEGIN
	DECLARE @baseRate DECIMAL(15,2) = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)

    DECLARE @RoomID INT = 
	(
	SELECT TOP(1) r.Id FROM rooms r
    join hotels h ON r.hotelID = h.id
    join trips t ON t.roomid = r.id
    where h.Id = @HotelId AND Beds >= @People
	GROUP BY r.Id
	ORDER BY MAX(Price) DESC
	)
	
	DECLARE @temp INT = (SELECT r.Price
	FROM Hotels AS h
	LEFT JOIN Rooms AS r ON r.HotelId = h.Id
	WHERE r.Id = @RoomId AND r.Id NOT IN (SELECT RoomId FROM Trips WHERE @Date BETWEEN ArrivalDate AND ReturnDate AND CancelDate IS  NULL
	GROUP BY RoomId)
	)

	IF(@temp IS NULL) RETURN 'No rooms available'

	
	

	DECLARE @RoomType NVARCHAR(50) = (SELECT [Type] FROM Rooms WHERE Id = @RoomID)

	DECLARE @RoomPrice NVARCHAR(50) = (SELECT Price FROM Rooms WHERE Id = @RoomID)
	
	DECLARE @BedsCount INT = (SELECT Beds FROM Rooms WHERE Id = @RoomID)

    DECLARE @TotalPrice DECIMAL(15,2)  =  (@baseRate + @RoomPrice) * @People
    return CONCAT('Room',' ' ,@RoomID,': ' ,@RoomType,' (',@BedsCount,' beds)' ,' - $',@TotalPrice)
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)


SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

-----12
go

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @hotelIdFromTrip INT = (
	SELECT HotelId FROM Trips AS tr
	JOIN Rooms AS r ON tr.RoomId = r.Id
	WHERE tr.Id = @TripId)

	DECLARE @hotelIdFromRoom INT = (
	SELECT HotelId
	FROM Rooms AS r
	WHERE r.Id = @TargetRoomId)

	IF(@hotelIdFromRoom != @hotelIdFromTrip) THROW 50001, 'Target room is in another hotel!',1

	DECLARE @countOfPeople INT = (
	SELECT COUNT(AccountId)
	FROM AccountsTrips
	WHERE TripId = 10
	GROUP BY TripId)

	DECLARE @bedsCount INT = (
	SELECT Beds FROM Rooms AS r
	WHERE r.Id = @TargetRoomId)

	IF(@countOfPeople > @bedsCount) THROW 50002, 'Not enough beds in target room!',1

	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId
END


EXEC usp_SwitchRoom 10, 8

EXEC usp_SwitchRoom 10, 7

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
