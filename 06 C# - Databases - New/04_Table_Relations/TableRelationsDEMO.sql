CREATE TABLE Country(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name]  NVARCHAR(50) NOT NULL UNIQUE
)

SELECT * 
	FROM Courses
	JOIN Towns ON Courses.CityName = Towns.[Name]

CREATE TABLE Mountains
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
)

CREATE TABLE Peaks
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	MountainId INT FOREIGN KEY REFERENCES Mountains(Id)
)

SELECT c.CourseName,t.Name,t.Population
	FROM Courses AS c
	JOIN Towns AS t ON c.CityName = t.Name
	WHERE t.Population >= 30000
	ORDER BY c.CourseName

SELECT m.MountainRange,p.PeakName,p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
	JOIN Countries AS c ON c.CountryCode =mc.CountryCode
	WHERE m.MountainRange = 'Rila'
	ORDER BY Elevation DESC