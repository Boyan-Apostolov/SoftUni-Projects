--1
CREATE TABLE Passports(
PassportID INT PRIMARY KEY,
PassportNumber NVARCHAR(8)
)

CREATE TABLE Persons(
PersonID INT PRIMARY KEY,
FirstName NVARCHAR(50),
Salary DECIMAL(10,2),
PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportID,PassportNumber) VALUES
(101,'N34FG21B'),(102,'K65LO4R7'),(103,'ZE657QP2')

INSERT INTO Persons(PersonID,FirstName,Salary,PassportID) VALUES
(1,'Roberto',43300.00,102),
(2,'Tom',56100.00,103),
(3,'Yana',60200.00,101)

go

--2
CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY,
[Name] NVARCHAR(50),
EstablishedOn DATE
)

CREATE TABLE Models(
ModelID INT PRIMARY KEY,
[Name] NVARCHAR(50),
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers(ManufacturerID,[Name],EstablishedOn) VALUES
(1,'BMW', '01/03/1916'),
(2,'Tesla', '01/01/2003'),
(3,'Lada', '01/05/1966')

INSERT INTO Models(ModelID,[Name],ManufacturerID) VALUES
(101,'X1',1),
(102,'i6',1),
(103,'Model S', 2),
(104,'Model X', 2),
(105, 'Model 3',2),
(106,'Nova',3)


go

--3
CREATE TABLE Students(
StudentId INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT FOREIGN KEY REFERENCES Students(StudentId),
ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
PRIMARY KEY(StudentID,ExamID)
)

INSERT INTO Students([Name]) VALUES
('Mila'), ('Toni'),('Ron')

INSERT INTO Exams(ExamID,[Name]) VALUES
(101,'SpringMVC'), (102,'Neo4j'), (103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID,ExamID) VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)
go

--4
CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY,
[Name] NVARCHAR(30),
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID,[Name]) VALUES
(101,'John')

INSERT INTO Teachers(TeacherID,[Name],ManagerID) VALUES
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted',105),
(105,'Mark',101),
(106,'Greta',101)



--6
CREATE DATABASE University
use University

CREATE TABLE Majors(
MajorID INT PRIMARY KEY,
[Name] NVARCHAR(30) NOT NULL,
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
StudentNumber NVARCHAR(15) NOT NULL,
StudentName NVARCHAR(50) NOT NULL,
MakorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY,
PaymentDate SMALLDATETIME NOT NULL,
PaymentAmount DECIMAL(10,2) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY,
SubjectName NVARCHAR(30) NOT NULL
)

CREATE TABLE Agenda(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID) NOT NULL,
PRIMARY KEY(StudentID,SubjectID)
)
go

--5
CREATE TABLE Cities(
CityID INT PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY,
[Name] VARCHAR(50),
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
[Name] VARCHAR(50),
Birthdate DATE,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
PRIMARY KEY(OrderID,ItemID)
)


go
--9
Use Geography

SELECT m.MountainRange,p.PeakName,p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
go