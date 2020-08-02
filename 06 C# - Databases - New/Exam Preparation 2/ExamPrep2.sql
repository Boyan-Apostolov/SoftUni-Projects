CREATE DATABASE School2
GO
USE School2
GO

CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK(Age BETWEEN 5 AND 100),
	[Address] NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3,2) CHECK (Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(3,2) CHECK (Grade BETWEEN 2 AND 6) NOT NULL
	PRIMARY KEY(StudentId,ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId INT FOREIGN KEY REFERENCES Students(Id),
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id),
	PRIMARY KEY(StudentId,TeacherId)
)
go

-----2
INSERT INTO Teachers(FirstName,LastName,[Address],Phone,SubjectId) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects([Name],Lessons) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

-----3
UPDATE StudentsSubjects
SET Grade = 6
WHERE SubjectId IN (1,2) AND Grade >= 5.50

-----4
DELETE StudentsTeachers WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
	WHERE Phone LIKE '%72%'

-----5
SELECT FirstName,LastName,Age
	FROM Students
	WHERE Age >= 12
	ORDER BY FirstName,LastName

-----6
SELECT s.FirstName,s.LastName, COUNT(t.Id) AS TeachersCount
	FROM StudentsTeachers as st
	JOIN Students AS s ON s.Id = st.StudentId
	JOIN Teachers AS t ON t.Id = st.TeacherId
	GROUP BY s.FirstName,s.LastName

-----7
SELECT CONCAT(s.FirstName,' ',s.LastName) AS [Full Name]
	FROM Students as s
	LEFT JOIN StudentsExams as se ON s.Id = se.StudentId
	WHERE se.Grade IS NULL
	ORDER BY [Full Name]

-----8
SELECT TOP(10) k.FirstName,k.LastName,FORMAT(k.Grade,'N2') AS Grade
	FROM
(SELECT s.FirstName AS FirstName ,s.LastName AS LastName,AVG(se.Grade) AS [Grade]
		FROM Students AS s
		JOIN StudentsExams AS se ON se.StudentId = s.Id
		GROUP BY s.FirstName,s.LastName
		) as k
	ORDER BY Grade DESC,k.FirstName,k.LastName

-----9
SELECT CONCAT(FirstName, ' ', COALESCE(MiddleName+ ' ',''), LastName) AS [Full Name] 
	FROM Students aS s 
	LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
	WHERE ss.Id IS NULL
	ORDER BY [Full Name]

-----10
SELECT s.Name, AVG(ss.Grade) AS AverageGrade
	FROM Subjects AS s
	JOIN StudentsSubjects AS ss ON s.Id = ss.SubjectId
	GROUP BY s.Id,s.Name
	ORDER BY s.Id

-----11
go
CREATE OR ALTER FUNCTION udf_ExamGradesToUpdate(@studentId INT , @grade DECIMAL(3,2))
RETURNS NVARCHAR(500)
AS
BEGIN
DECLARE @temp INT = (SELECT Id FROM Students WHERE Id = @studentId)
	IF(@temp IS NULL) RETURN ('The student with provided id does not exist in the school!')
	
	IF(@grade > 6.00) RETURN ('Grade cannot be above 6.00!')

	DECLARE @endGrade DECIMAL(3,2) = @grade + 0.5

	DECLARE @countOfGrades INT = (
		SELECT COUNT(k.Grade) FROM(SELECT * FROM Students as s 
			JOIN StudentsExams as se ON se.StudentId = @studentId
			WHERE s.Id = 12) AS k
		WHERE k.Grade BETWEEN @grade AND @endGrade)

		DECLARE @studentName NVARCHAR(30) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	RETURN CONCAT('You have to update ',@countOfGrades,' grades for the student ',@studentName)
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)
go
-----12
go
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @temp INT = (SELECT Id FROM Students WHERE Id = @studentId)
	IF(@temp IS NULL) RAISERROR('This school has no student with the provided id!', 16, 1)

	DELETE FROM StudentsSubjects WHERE StudentId = @StudentId
	DELETE FROM StudentsExams WHERE StudentId = @StudentId
	DELETE FROM StudentsTeachers WHERE StudentId = @StudentId
	DELETE FROM Students WHERE Id = @StudentId

END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students
EXEC usp_ExcludeFromSchool 301

go


