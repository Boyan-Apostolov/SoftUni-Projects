--Char/VarChar/NVarChar
--DECLARE @MyChar CHAR(10)  = 'Test'
--DECLARE @MyVarChar VARCHAR(10)  = 'Test'
--DECLARE @MyNVarChar NVARCHAR(10)  = 'Test'

--SELECT @MyChar AS MyChar, @MyVarChar AS MyVarChar,@MyNVarChar AS MyNVarChar

--Show All
SELECT * FROM Students

--Insert In Table
INSERT INTO Students ( FirstName, LastName, Balance) VALUES ( 'test', 'test', 345.123456)

--Delete Table
DROP TABLE Students

--Create Table
CREATE TABLE Students
(
ID INT PRIMARY KEY IDENTITY(1,1),
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,
)

--Modify Table
ALTER TABLE Students
--Add constraint - Only Be Able To Add FirstName Longer Than 3 symbols
ADD CONSTRAINT CHK_StudentFirstName CHECK (LEN(FirstName)>=3);

--Length Of String
SELECT LEN(FirstName) FROM Students

--Modify Table
ALTER TABLE Students
--Add column Balance to Table
Add Balance DECIMAL(15,3)