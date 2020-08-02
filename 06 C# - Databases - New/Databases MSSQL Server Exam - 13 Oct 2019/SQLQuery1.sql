CREATE DATABASE Bitbucket
GO
use Bitbucket
go

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NOT NULL,
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	PRIMARY KEY(RepositoryId,ContributorId)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
		ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
)

CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Size DECIMAL(15,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)

-----2
INSERT INTO Files(Name,Size,ParentId,CommitId) VALUES
('Trade.idk',	2598.0,		1,	1),
('menu.net',	9238.31,	2,	2),
('Administrate.soshy',	1246.93,	3,	3),
('Controller.php',	7353.15,	4,	4),
('Find.java',	9957.86,	5,	5),
('Controller.json',	14034.87,	3,	6),
('Operate.xix',	7662.92,	7,	7)

INSERT INTO Issues(Title,IssueStatus,RepositoryId,AssigneeId) VALUES
('Critical Problem with HomeController.cs file',	'open',	1,	4),
('Typo fix in Judge.html','open',	4,	3),
('Implement documentation for UsersService.cs','closed',	8,	2),
('Unreachable code in Index.cs','open',	9,	8)

-----3
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

-----4
 DELETE Issues
 WHERE RepositoryId IN
 (SELECT Id FROM Repositories WHERE Name = 'Softuni-Teamwork')

 DELETE RepositoriesContributors 
 WHERE RepositoryId IN
 (SELECT Id FROM Repositories WHERE Name = 'Softuni-Teamwork')

 -----5
 SELECT Id,Message,RepositoryId,ContributorId
	FROM Commits
	ORDER BY Id,Message,RepositoryId,ContributorId

-----6
SELECT Id,Name,Size
	FROM Files
	WHERE Size > 1000 AND Name LIKE '%html%'
	ORDER BY Size DESC,Id,Name

-----7
SELECT i.Id, CONCAT(u.Username,' : ',i.Title) AS IssueAssignee 
	FROM Issues AS i
	JOIN Users as u ON i.AssigneeId = u.Id
	ORDER BY i.Id DESC, u.Username

-----8
SELECT f1.Id,f1.[Name], CONCAT(f1.Size,'KB') AS [Size]
	FROM Files as f1
	LEFT JOIN Files as f2 ON f1.Id = f2.ParentId
	WHERE f2.Id IS NULL
	ORDER BY f1.Id,f1.[Name],f1.Size DESC

-----9
SELECT TOP(5) r.Id, r.[Name], COUNT(c.RepositoryId) AS [Commits]
	FROM Repositories AS r
	JOIN Commits AS c ON c.RepositoryId = r.Id
	LEFT JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
	GROUP BY r.Id, r.[Name]
	ORDER BY [Commits] DESC, r.Id, r.[Name]

-----10
SELECT u.Username, AVG(f.Size) AS [Size]
	FROM Users as u
	JOIN Commits AS c ON u.Id = c.ContributorId
	JOIN Files AS f ON f.CommitId = c.Id
	GROUP BY u.Username
	ORDER BY [Size] DESC,u.Username ASC

-----11
go
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT TOP(1) COUNT(c.Id) 
											FROM Users as u
											JOIN Commits as c ON c.ContributorId = u.Id
											WHERE u.Username = @username
											GROUP BY u.Username
											)
	
END
go

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

-----12
go
CREATE PROC usp_FindByExtension(@extension VARCHAR(10))
AS
BEGIN
	SELECT Id,Name, CONCAT(Size,'KB') AS Size
		FROM Files
		WHERE Name LIKE '%'+@extension
		ORDER BY Id,Name,Size DESC
END

EXEC usp_FindByExtension 'txt'