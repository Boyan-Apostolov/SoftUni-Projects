CREATE DATABASE School
USE School
CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT CHECK (Age > 5 AND Age < 100),
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
	StudentId INT NOT NULL REFERENCES Students(Id),
	SubjectId INT NOT NULL REFERENCES Subjects(Id),
	Grade DECIMAL(3,2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6)
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME2,
	SubjectId INT NOT NULL REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams(
	StudentId INT NOT NULL REFERENCES Students(Id),
	ExamId INT NOT NULL FOREIGN KEY REFERENCES Exams(Id),
	Grade DECIMAL(3,2) NOT NULL CHECK(Grade >= 2 AND Grade <= 6),
	PRIMARY KEY(StudentId,ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone NCHAR(10),
	SubjectId INT NOT NULL REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers(
	StudentId INT NOT NULL REFERENCES Students(Id),
	TeacherId INT NOT NULL REFERENCES Teachers(Id),
	PRIMARY KEY(StudentId,TeacherId)
)

-----
INSERT INTO Subjects(Name,Lessons) VALUES
('Geometry',12),
('Health', 10),
('Drama',7),
('Sports',9)

INSERT INTO Teachers(FirstName,LastName, Address,Phone,SubjectId) VALUES
('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin	','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4)

-----
UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1,2) AND Grade >= 5.50

----
DELETE StudentsTeachers WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%' )
DELETE Teachers WHERE Id IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%' )

-----
SELECT FirstName,LastName,Age 
	FROM Students WHERE Age >= 12
	ORDER BY FirstName,LastName

-----
SELECT CONCAT(FirstName,' ', MiddleName,' ', LastName) AS [Full name],
	   [Address]
	FROM Students
	WHERE [Address] LIKE '%road%'
	ORDER BY FirstName,LastName,Address
	
-----
SELECT FirstName,Address,Phone
	FROM Students
	WHERE MiddleName IS NOT NULL AND Phone LIKE '42%'
	ORDER BY FirstName

-----
SELECT s.FirstName,s.LastName,COUNT(st.TeacherId)
	FROM Students as s
	JOIN StudentsTeachers as st ON s.Id = st.StudentId
	GROUP BY s.FirstName,s.LastName

-----
SELECT CONCAT(t.FirstName,' ',t.LastName) as [FullName],
	   CONCAT(sub.[Name],'-',sub.Lessons) AS [Subjects],
	   COUNT(st.StudentId) AS [Students]
	FROM Teachers as t
	JOIN Subjects as sub ON t.SubjectId = sub.Id
	JOIN StudentsTeachers as st ON st.TeacherId = t.Id
	GROUP BY t.FirstName,t.LastName,sub.Name,sub.Lessons
	ORDER BY COUNT(st.StudentId) DESC, [FullName] ASC, [Subjects] ASC

----

SELECT CONCAT(FirstName,' ',LastName) AS [Full Name]
	FROM Students as s
	LEFT JOIN StudentsExams as se ON se.StudentId = s.Id
	WHERE se.ExamId IS NULL
	ORDER BY [Full Name]

-----
SELECT TOP(10) t.FirstName,t.LastName,
	   COUNT(st.StudentId) AS [StudentsCount]
	FROM Teachers as t
	JOIN Subjects as sub ON t.SubjectId = sub.Id
	JOIN StudentsTeachers as st ON st.TeacherId = t.Id
	GROUP BY t.FirstName,t.LastName
	ORDER BY StudentsCount DESC,FirstName ASC,LastName ASC

-----
SELECT TOP(10) FirstName,LastName,CAST(AVG(se.Grade) AS DECIMAL(3,2)) [AS Grade]
	FROM Students AS s
	JOIN StudentsExams AS se ON s.Id = se.StudentId
	GROUP BY FirstName,LastName
	ORDER BY CAST(AVG(se.Grade) AS DECIMAL(3,2)) DESC, FirstName,LastName

-----
SELECT k.FirstName,k.LastName,k.Grade FROM (SELECT TOP(10) FirstName,LastName,Grade AS [Grade],
ROW_NUMBER() OVER (PARTITION BY FirstName, LastName ORDER BY se.Grade DESC) AS RowNumber
	FROM Students AS s
	JOIN StudentsExams AS se ON s.Id = se.StudentId) as k
WHERE RowNumber = 2
	ORDER BY Grade DESC, FirstName,LastName -- NOT DONE RIP

-----
SELECT CONCAT(FirstName, ' ', COALESCE(MiddleName+ ' ',''), LastName) AS [Full Name] 
	FROM Students AS s
	LEFT JOIN StudentsSubjects AS ss ON s.Id = ss.StudentId
	WHERE ss.SubjectId IS NULL
	ORDER BY [Full Name]

-----
SELECT s.Name, AVG(ss.Grade) AS [Average Grade]
	FROM Subjects as s
	JOIN StudentsSubjects as ss ON ss.SubjectId = s.Id
	GROUP BY s.Name,s.Id
	ORDER BY s.Id

-----
SELECT k.Quarter,k.Name,COUNT(k.StId) AS StudentsCount FROM
(SELECT 
	CASE DATEPART(QUARTER,e.Date)
		WHEN 1 THEN 'Q1'
		WHEN 2 THEN 'Q2'
		WHEN 3 THEN 'Q3'
		WHEN 4 THEN 'Q4'
		WHEN IS NULL THEN 'TBA'
END AS [Quarter],
	s.Name AS Name, ss.StudentId AS StId
	FROM StudentsExams as se
	JOIN Exams as e ON se.ExamId = e.Id
	JOIN Subjects as s ON e.SubjectId = s.Id
	JOIN StudentsSubjects as ss ON ss.SubjectId = s.Id
	WHERE ss.Grade > 4.00) as k
GROUP BY k.Quarter,k.Name
ORDER BY Quarter ASC

-----
go
CREATE OR ALTER FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS NVARCHAR(100)
AS
BEGIN 
	DECLARE @maxGrade INT = @grade + 0.50;

		IF(@grade > 6) RETURN ('Grade cannot be above 6.00!');

		IF NOT EXISTS (SELECT * FROM Students WHERE Id = @studentId) RETURN ('The student with provided id does not exist in the school!')

		DECLARE @countOfGrades INT;

		SET @countOfGrades = (SELECT COUNT(Grade) FROM StudentsExams
		WHERE StudentId = @studentId AND Grade >= @grade AND Grade <= @maxGrade)

		DECLARE @StudentName VARCHAR(50);

		SET @StudentName = (SELECT FirstName FROM Students WHERE Id = @studentId)

	RETURN ('You have to update '+CAST(@countOfGrades AS nvarchar(10))+' grades for the student '+@StudentName)
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)

SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

-----\
go
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Students WHERE Id = @studentId) RETURN ('This school has no student with the provided id!')
	
DELETE StudentsSubjects WHERE StudentId = @StudentId

DELETE StudentsExams WHERE StudentId = @StudentId

DELETE StudentsTeachers WHERE StudentId = @StudentId

DELETE Students WHERE Id = @StudentId
END

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301
