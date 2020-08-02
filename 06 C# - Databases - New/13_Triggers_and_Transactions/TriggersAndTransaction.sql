CREATE PROC usp_TransferFunds(@fromAccountId INT,@toAccountId INT, @amount MONEY)
AS
BEGIN TRANSACTION
	IF(@amount < 0)
	BEGIN
		ROLLBACK;
		THROW 51533, 'Invalid amount', 1
	END

	IF ((SELECT COUNT(*) FROM Accounts WHERE Id = @fromAccountId) != 1)
	BEGIN
		ROLLBACK;
		THROW 51502, 'Invalid from account id', 1
	END

	IF ((SELECT COUNT(*) FROM Accounts WHERE Id = @toAccountId) != 1)
	BEGIN
		ROLLBACK;
		THROW 51503, 'Invalid to account id', 1
	END

	IF((SELECT Balance FROM Accounts WHERE Id = @fromAccountId) < @amount)
	BEGIN
		ROLLBACK;
		THROW 56478, 'Insufficiend funds',1
	END

	UPDATE Accounts SET Balance = Balance - @amount WHERE Id = @fromAccountId
	UPDATE Accounts SET Balance = Balance + @amount WHERE Id = @toAccountId

COMMIT
GO

CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE
AS

IF (EXISTS(
	SELECT * FROM inserted
	WHERE Name IS NULL OR LEN(Name) = 0))

BEGIN
	RAISERROR('Town name cannot be empty.', 16, 1)
	ROLLBACK
	RETURN
END

UPDATE Towns SET Name = '' WHERE TownID = 1

go

CREATE OR ALTER TRIGGER tr_SetIsDeletedOnDelete ON AccountHolders
INSTEAD OF DELETE
AS
	UPDATE ah SET ah.isDeleted = 1
		FROM AccountHolders as ah
		JOIN deleted as d ON d.Id = ah.Id

DELETE FROM AccountHolders WHERE AccountHolders.FirstName LIKE '%a%'

go

CREATE TABLE Logs(
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldAmount money NOT NULL,
	NewAmount money not null,
	UpdatedON datetime2,
	UpdatedBy NVARCHAR(MAX),
)
go

CREATE OR ALTER TRIGGER tr_AddToLogsOnAccountUpdate ON Accounts
FOR UPDATE
AS
	INSERT INTO Logs(AccountId,OldAmount,NewAmount,UpdatedON,UpdatedBy) 
		SELECT i.Id, i.Balance, d.Balance, GETDATE(), CURRENT_USER
			FROM inserted as i
			JOIN deleted as d ON d.Id = i.Id
			WHERE i.Balance != d.Balance


UPDATE Accounts SET Balance = Balance + 1
SELECT * FROM Logs

SELECT * FROM Accounts
EXEC usp_TransferFunds 15,12,15000