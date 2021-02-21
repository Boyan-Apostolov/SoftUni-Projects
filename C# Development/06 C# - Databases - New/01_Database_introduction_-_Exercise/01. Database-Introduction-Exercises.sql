--1
CREATE DATABASE Minions

USE Minions

--2
go
CREATE TABLE Minions(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50),
	Age TINYINT
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50)
)

go

--3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--4
INSERT INTO Towns(Id,[Name]) VALUES
(1, 'Sofia'), (2, 'Plovdiv'), (3, 'Varna')

INSERT INTO Minions(Id,[Name],Age,TownId) VALUES
(1,'Kevin', 22, 1),
(2,'Bob',15 ,3),
(3,'Steward',NULL ,2)
go

--5
TRUNCATE TABLE Minions
go 

--6
DROP TABLE Minions
DROP TABLE Towns

go
--7
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	Height DECIMAL(5,2),
	Weight DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name],Gender,Birthdate) VALUES
('Georgi','m','2020-05-19'),
('Petar','m','2004-07-13'),
('Ivana','f','2008-05-16'),
('Vacha','f','2020-01-23'),
('Bobi','m','2020-11-01')
go
--8
CREATE TABLE Users(
	ID BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900*1024),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users(Username,[Password],LastLoginTime, IsDeleted) VALUES
('Pesho0','123456','05.19.2020', 0),
('Pesho1','123456','05.19.2020', 1),
('Pesho2','123456','05.19.2020', 0),
('Pesho3','123456','05.19.2020', 0),
('Pesho4','123456','05.19.2020', 1)
go

--9
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC275067E69C]

ALTER TABLE Users 
ADD CONSTRAINT PK_Users_IdUsername_Composite
PRIMARY KEY(Id,Username)
go

--10
ALTER TABLE Users
ADD CONSTRAINT CK_UsersPasswordLength
CHECK(LEN([Password]) >= 5)
go

--11
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTIme
DEFAULT GETDATE() FOR LastLoginTime
go

--12
ALTER TABLE Users
DROP CONSTRAINT PK_Users_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id),
CHECK(LEN(Username)>=3)
go

--13
CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Directors(DirectorName) VALUES
('Pesho'),('Georgi'),('Ivan'),('Simona'),('Emil')

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Genres(GenreName) VALUES
('Cool'),('Nerdy'),('Action'),('Romantic'),('Sci-Fi')

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Categories(CategoryName) VALUES
('Cool'),('Nerdy'),('Action'),('Romantic'),('Sci-Fi')

CREATE TABLE Movies(
	ID INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear DATE,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
)
INSERT INTO Movies(Title,DirectorId,[Length],GenreId,CategoryId) VALUES
('Movie1',1,1,1,1),
('Movie2',2,2,2,2),
('Movie3',3,3,3,3),
('Movie4',4,4,4,4),
('Movie5',5,5,5,5)

go

--14
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(4,2) NOT NULL,
	WeeklyRate DECIMAL(4,2) NOT NULL,
	MonthlyRate DECIMAL(4,2) NOT NULL,
	WeekendRate DECIMAL(4,2) NOT NULL,
)
INSERT INTO Categories(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate) VALUES
('Category 1',1.1,1.1,1.1,1.1),
('Category 2',2.2,2.2,2.2,2.2),
('Category 3',3.3,3.3,3.3,3.3)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(50) NOT NULL,
	Manufacturer NVARCHAR(50) NOT NULL,
	Model NVARCHAR(50) NOT NULL,
	CarYear NVARCHAR(4) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(50),
	Available NVARCHAR(50)
)
INSERT INTO Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors) VALUES
('BT9190VM','Remault','Idk Bro','2020',1,1),
('BT9190VM','Remault','Idk Bro','2020',2,2),
('BT9190VM','Remault','Idk Bro','2020',3,3)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
)
INSERT INTO Employees(FirstName,LastName,Title) VALUES
('FN1','LN1','T1'),
('FN2','LN2','T2'),
('FN3','LN3','T3')

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber NVARCHAR(10) NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(50),
	City NVARCHAR(50) NOT NULL,
	ZIPCode INT,
	Notes NVARCHAR(MAX)
)
INSERT INTO Customers(DriverLicenceNumber,FullName,City) VALUES
('VT9395VM','Jhonny Jhonny', 'Veliko Tarnovo'),
('SA9637JF', 'Bobby Apostolov', 'Sofia'),
('RV1234RM', 'Nikoleta Marinova', 'Gabrovo')

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CusomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays INT, 
    RateApplied DECIMAL(10, 2),
    TaxRate DECIMAL(10, 2),
    OrderStatus NVARCHAR(50),
    NOTES NVARCHAR(MAX)
)
INSERT INTO RentalOrders(EmployeeId,CusomerId,CarId,StartDate,EndDate) VALUES
(1,1,1,'2020-05-05','2020-05-25'),
(2,2,2,'2020-05-05','2020-05-25'),
(3,3,3,'2020-05-05','2020-05-25')
go

--15
USE Hotel;

CREATE TABLE Employees
(
             Id        INT
             PRIMARY KEY NOT NULL,
             FirstName NVARCHAR(50) NOT NULL,
             LastName  NVARCHAR(50) NOT NULL,
             Title     NVARCHAR(255) NOT NULL,
             Notes     NVARCHAR(MAX)
);

INSERT INTO Employees(Id,
                      FirstName,
                      LastName,
                      Title
                     )
VALUES
(
       1,
       'First',
       'Employee',
       'Manager'
),
(
       2,
       'Second',
       'Employee',
       'Manager'
),
(
       3,
       'Third',
       'Employee',
       'Manager'
);

CREATE TABLE Customers
(
             AccountNumber   INT
             PRIMARY KEY NOT NULL,
             FirstName       NVARCHAR(50) NOT NULL,
             LastName        NVARCHAR(50) NOT NULL,
             PhoneNumber     VARCHAR(50),
             EmergencyName   NVARCHAR(50) NOT NULL,
             EmergencyNumber INT NOT NULL,
             Notes           NVARCHAR(50)
);

INSERT INTO Customers(AccountNumber,
                      FirstName,
                      LastName,
                      EmergencyName,
                      EmergencyNumber
                     )
VALUES
(
       1,
       'First',
       'Customer',
       'Em1',
       11111
),
(
       2,
       'Second',
       'Customer',
       'Em2',
       22222
),
(
       3,
       'Third',
       'Customer',
       'Em3',
       33333
);

CREATE TABLE RoomStatus
(
             RoomStatus NVARCHAR(50)
             PRIMARY KEY NOT NULL,
             Notes      NVARCHAR(MAX)
);

INSERT INTO RoomStatus(RoomStatus)
VALUES
(
       'Free'
),
(
       'In use'
),
(
       'Reserved'
);

CREATE TABLE RoomTypes
(
             RoomType NVARCHAR(50)
             PRIMARY KEY NOT NULL,
             Notes    NVARCHAR(MAX)
);

INSERT INTO RoomTypes(RoomType)
VALUES
(
       'Luxory'
),
(
       'Casual'
),
(
       'Misery'
);

CREATE TABLE BedTypes
(
             BedType NVARCHAR(50)
             PRIMARY KEY NOT NULL,
             Notes   NVARCHAR(MAX)
);

INSERT INTO BedTypes(BedType)
VALUES
(
       'Single'
),
(
       'Double'
),
(
       'King'
);

CREATE TABLE Rooms
(
             RoomNumber INT
             PRIMARY KEY NOT NULL,
             RoomType   NVARCHAR(50) NOT NULL,
             BedType    NVARCHAR(50) NOT NULL,
             Rate       DECIMAL(10, 2) NOT NULL,
             RoomStatus NVARCHAR(50) NOT NULL,
             Notes      NVARCHAR(MAX)
);

INSERT INTO Rooms(RoomNumber,
                  RoomType,
                  BedType,
                  Rate,
                  RoomStatus
                 )
VALUES
(
       1,
       'Luxory',
       'King',
       100,
       'Reserved'
),
(
       2,
       'Casual',
       'Double',
       50,
       'In use'
),
(
       3,
       'Misery',
       'Single',
       19,
       'Free'
);

CREATE TABLE Payments
(
             Id                INT
             PRIMARY KEY NOT NULL,
             EmployeeId        INT NOT NULL,
             PaymentDate       DATE NOT NULL,
             AccountNumber     INT NOT NULL,
             FirstDateOccupied DATE NOT NULL,
             LastDateOccupied  DATE NOT NULL,
             TotalDays         INT NOT NULL,
             AmountCharged     DECIMAL(10, 2) NOT NULL,
             TaxRate           DECIMAL(10, 2) NOT NULL,
             TaxAmount         DECIMAL(10, 2) NOT NULL,
             PaymentTotal      DECIMAL(10, 2) NOT NULL,
             Notes             NVARCHAR(MAX)
);

ALTER TABLE Payments
ADD CONSTRAINT CK_TotalDays CHECK(DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied) = TotalDays);

ALTER TABLE Payments
ADD CONSTRAINT CK_TaxAmount CHECK(TaxAmount = TotalDays * TaxRate);

INSERT INTO Payments(Id,
                     EmployeeId,
                     PaymentDate,
                     AccountNumber,
                     FirstDateOccupied,
                     LastDateOccupied,
                     TotalDays,
                     AmountCharged,
                     TaxRate,
                     TaxAmount,
                     PaymentTotal
                    )
VALUES
(
       1,
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
       2,
       3,
       '10-11-2015',
       1,
       '12-15-2015',
       '12-25-2015',
       10,
       100,
       50,
       500,
       100
),
(
       3,
       2,
       '12-23-2015',
       1,
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
             Id            INT
             PRIMARY KEY NOT NULL,
             EmployeeId    INT NOT NULL,
             DateOccupied  DATE NOT NULL,
             AccountNumber INT NOT NULL,
             RoomNumber    INT NOT NULL,
             RateApplied   DECIMAL(10, 2),
             PhoneCharge   VARCHAR(50) NOT NULL,
             Notes         NVARCHAR(MAX)
);

INSERT INTO Occupancies(Id,
                        EmployeeId,
                        DateOccupied,
                        AccountNumber,
                        RoomNumber,
                        PhoneCharge
                       )
VALUES
(
       1,
       2,
       '08-24-2012',
       3,
       1,
       '088 88 888 888'
),
(
       2,
       3,
       '06-15-2015',
       2,
       3,
       '088 88 555 555'
),
(
       3,
       1,
       '05-12-1016',
       1,
       2,
       '088 88 555 333'
);
go

--16
CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

go

--18
INSERT INTO Towns([Name]) VALUES
('Sofia'),('Plovdiv'),('Varna'),('Burgas')

INSERT INTO Departments([Name]) VALUES
('Engineering'),('Sales'),('Marketing'),('Software Development'),('Quality Assurance')

INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary) VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00),
('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00),
('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
('Georgi','Terziev','Ivanov','CEO',2,'2007-12-09',3000.00),
('Peter','Pan','Pan','Intern',3,'2026-08-28',599.88)
go

go
--19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees
go

--20
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY Salary DESC
go

--21
SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName,LastName,JobTitle,Salary FROM Employees ORDER BY Salary DESC
go

--22
go
UPDATE Employees
SET Salary = Salary + (Salary*0.1)

SELECT Salary FROM Employees 
--23
go

--23
UPDATE Payments
SET TaxRate = TaxRate - (TaxRate*0.03)

SELECT TaxRate FROM Payments
go

--24
TRUNCATE TABLE Occupancies
go