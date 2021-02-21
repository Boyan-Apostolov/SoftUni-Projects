CREATE DATABASE Minions


USE Minions

CREATE TABLE Minions
(
Id INT NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
Age INT  
)

CREATE TABLE Towns
(
Id INT NOT NULL,
[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE Minions
ADD CONSTRAINT PK_Id
PRIMARY KEY(Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownId
PRIMARY KEY(Id)

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionTownId
FOREIGN KEY (TownId) REFERENCES Towns(Id)

INSERT INTO Towns(Id, [Name]) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions(Id,[Name], Age, TownId) Values
(1, 'Kevin',22,1),
(2, 'Bob',15,3),
(3, 'Steward',NULL,2)

SELECT [Id], [Name], [Age], [TownId] FROM Minions

--4
CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
CHECK(DATALENGTH(ProfilePicture)<= 921600),
LastLoginTime DATETIME2,
IsDeleted BIT  NOT NULL
)

INSERT INTO Users(Username,[Password],ProfilePicture,LastLoginTime, IsDeleted)
VALUES
('Pesho', '123', NULL, NULL, 0),
('Gosho', '123', NULL, NULL, 0),
('Ivan', '123', NULL, NULL, 0),
('Test', '123', NULL, NULL, 1),
('Test123', '123', NULL, NULL, 1)

SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0793D80627

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY(Id,Username)

--CHECK(LEN()<= ),

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username,[Password],ProfilePicture, IsDeleted)
VALUES
('Testtttt', '123', NULL,1)

SELECT * FROM Users

--ALTER TABLE Users
--ADD CONSTRAINT DF_LastLoginTime UNIQUE(Username)

CREATE TABLE People(
Id BIGINT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) UNIQUE NOT NULL,
Picture VARBINARY(MAX),
CHECK(DATALENGTH(Picture)<= 921600),
Height DECIMAL(3,2),
[Weight] DECIMAL(3,2),
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People([Name],Gender,Birthdate) VALUES
('First Namet', 'm', '01-01-2000'),
('First Namel', 'f', '01-01-2000'),
('First Namell', 'f', '01-01-2000'),
('First Namlll', 'm', '01-01-2000'),
('First Namellll', 'm', '01-01-2000')


SELECT * FROM People

CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50),
LastName NVARCHAR(50) NOT NULL,
Salary DECIMAL(8,2) NOT NULL
)

INSERT INTO Employees (FirstName,MiddleName,LastName, Salary) VALUES
('Boyan', 'Borislavov', 'Apostolov',2550.50),
('Gosho', NULL, 'Goshov', 1650.35),
('Ivan', NULL, 'Ivanov', 3150.45)

SELECT * FROM Employees
ORDER BY FirstName, LastName, Salary

SELECT TOP(1)* FROM Employees
ORDER BY Salary DESC 
GO

CREATE DATABASE Movies

use Movies

CREATE TABLE Directors
(
Id BIGINT PRIMARY KEY IDENTITY,
DirectorName VARCHAR(30) UNIQUE NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName) VALUES
('Pesho'),
('Georgi'),
('Ivan'),
('Bobi'),
('Nikoleta')

CREATE TABLE Genres
(
Id BIGINT PRIMARY KEY IDENTITY,
GenreName VARCHAR(30) UNIQUE NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Genres(GenreName) VALUES
('SCHIFI'),
('Romantic'),
('Crime'),
('Sad'),
('Horror')

CREATE TABLE Categories
(Id BIGINT PRIMARY KEY IDENTITY,
CategoryName VARCHAR(30) UNIQUE NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Categories(CategoryName) VALUES
('CategoryOne'),
('CategoryTwo'),
('CategoryThree'),
('CategoryFour'),
('CategoryFive')

CREATE TABLE Movies
(
Id BIGINT PRIMARY KEY IDENTITY,
Title VARCHAR(255) UNIQUE NOT NULL,
DirectorId BIGINT FOREIGN KEY REFERENCES Directors(Id),
CopyightYear INT,
[Length] INT,
GenreId BIGINT FOREIGN KEY REFERENCES Genres(Id),
Categories BIGINT FOREIGN KEY REFERENCES Categories(Id),
Rating INT,
Notes NVARCHAR(MAX)
)

INSERT INTO Movies(Title,DirectorId,GenreId,Categories) VALUES 
('Title One',2,3,4),
('Title Two',3,4,5),
('Title Three',1,2,3),
('Title Four',5,1,3),
('Title Five',3,5,2 )

SELECT * FROM Movies
--13 end
go

CREATE DATABASE CarRental 
use CarRental
CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName,LastName,Title) VALUES
('Boyan', 'Apostolov', 'CEO'),
('NIkoleta', 'Marinova', 'Accountant'),
('Dimitar', 'Ivanov', 'Manager')

CREATE TABLE Customers
(
AccountNumber INT PRIMARY KEY ,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber INT NOT NULL,
EmergencyName NVARCHAR(50) NOT NULL,
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(MAX)
)

INSERT INTO Customers (AccountNumber,FirstName,LastName,PhoneNumber,EmergencyName,EmergencyNumber) VALUES
(1, 'Boyan', 'Apsotolov', 0884203364, 'Tatyana', 0889493553),
(2, 'Nikoleta', 'Marinova', 0884203675, 'Dimirat', 0889054732),
(3, 'Dimitar', 'Ivanov', 0884443364, 'Ian', 0889493443)

CREATE TABLE RoomStatus
(
RoomStatus NVARCHAR(50) PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus(RoomStatus) VALUES
('Available'),
('Taken'),
('Closed')

CREATE TABLE RoomTypes
(
RoomType NVARCHAR(50) PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes(RoomType) VALUES
('Small'),
('Normal'),
('Big')

CREATE TABLE BedTypes
(
BedType NVARCHAR(50) PRIMARY KEY,
Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes(BedType) VALUES
('Small'),
('Normal'),
('Big')

CREATE TABLE ROOMS
(
RoomNumber INT PRIMARY KEY NOT NULL,
RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(10, 2),
RoomStatus NVARCHAR(50) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
Notes NVARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber,RoomType,BedType,Rate,RoomStatus)VALUES
(1,'Small','Small',5,'Available'),
(2, 'Normal', 'Normal',5,'Taken'),
(3, 'Big', 'Big',5,'Closed')

CREATE TABLE Payments
(
ID INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE,
AccountNumber INT,
FirstDayOccupied DATE,
LastDayOccupied DATE,
TotalDays INT,
AmountCharged DECIMAL(8,2),
TaxRate DECIMAL(10,2),
TaxAmount DECIMAL(10,2),
PaymentTotal DECIMAL(10,2),
Notes NVARCHAR(MAX)
)


INSERT INTO Payments(EmployeeId,PaymentDate,AccountNumber,FirstDayOccupied,LastDayOccupied,TotalDays,AmountCharged,TaxRate,TaxAmount,PaymentTotal) VALUES
(
       1,
       '10-05-2015',
       1,
       '10-05-2015',
       '10-10-2015',
       5,
       75,
       50,
       250,
       75
),
(
       3,
       '10-11-2015',
       2,
       '12-15-2015',
       '12-25-2015',
       10,
       100,
       50,
       500,
       100
),
(
       2,
       '12-23-2015',
       3,
       '12-23-2015',
       '12-24-2015',
       1,
       75,
       75,
       75,
       75
);

CREATE TABLE Occupancies 
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE,
AccountNumber INT,
RoomNumber INT FOREIGN KEY REFERENCES ROOMS(RoomNumber),
RateApplied INT,
PhoneCharge NVARCHAR(59),
Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies(
                        EmployeeId,
                        DateOccupied,
                        AccountNumber,
                        RoomNumber,
                        PhoneCharge
                       )
VALUES
(
       2,
       '08-24-2012',
       3,
       1,
       '088 88 888 888'
),
(
       3,
       '06-15-2015',
       2,
       3,
       '088 88 555 555'
),
(
       1,
       '05-12-1016',
       1,
       2,
       '088 88 555 333'
);