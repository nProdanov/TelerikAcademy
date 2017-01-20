-- Task 01.database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
--Accounts(Id(PK), PersonId(FK), Balance).
CREATE DATABASE BankAccounts
GO

USE BankAccounts

CREATE TABLE Persons(
	Id int IDENTITY PRIMARY KEY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	SSN char(13) NOT NULL
)
GO

CREATE TABLE Accounts(
	Id int IDENTITY PRIMARY KEY, 
	PersonId int NOT NULL,
	Balance money NOT NULL, 
	CONSTRAINT FK_Accounts_Persons
		FOREIGN KEY (PersonId)
		REFERENCES Persons(Id)
)
GO

INSERT Persons(FirstName, LastName, SSN)
VALUES ('Ivan', 'Angelov', '1234567891234'),
('Petar', 'Dimitrov', '1234567891235'),
('Georgi', 'Grigorov', '1234567891233')

INSERT Accounts(PersonId, Balance)
VALUES(1, 3400),
(1, 10),
(2, 20),
(3, 100),
(3,200)
GO

CREATE PROC usp_Persons_SelectAllFullNames
AS
SELECT FirstName + ' ' + LastName as [Full Name]
FROM Persons
GO

-- Task 02. stored procedure that accepts a number as a parameter 
--and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_Persons_ReturnPersonWhoHaveMoreMoney
	(@InputMoney money)
AS 
		SELECT FirstName, LastName, Balance
		FROM Persons as p
		JOIN Accounts as a
		ON a.PersonId = p.Id
		WHERE a.Balance > @InputMoney
GO

-- Task 03.function that accepts as parameters – sum, yearly interest rate and number of months.
USE BankAccounts
GO
CREATE FUNCTION ufn_CalculateInterestedSum(
	@Sum MONEY, 
	@YearlyInterestRate REAL,
	@Months int
)
	RETURNS MONEY
AS
BEGIN
RETURN (@YearlyInterestRate / 12 * @Months * @Sum) + @Sum
END
GO

DECLARE @InterestedLoan MONEY
EXEC @InterestedLoan = ufn_CalculateInterestedSum 10, 1.2, 4
PRINT @InterestedLoan 
GO


-- Task 04. procedure that uses the function from the previous example to 
--give an interest to a person's account for one month.
USE BankAccounts
GO
CREATE PROC usp_Persons_InterestedSumInBalanceForOneMonth(
	@AccountId int,
	@InterestRate REAL
)
AS
	SELECT dbo.ufn_CalculateInterestedSum(Balance, @InterestRate, 1) 
	FROM Accounts
	WHERE Id = @AccountId
GO

USE BankAccounts
GO
EXEC usp_Persons_InterestedSumInBalanceForOneMonth 2, 1.2
GO

-- Task 05. stored procedures WithdrawMoney(AccountId, money) and 
--DepositMoney(AccountId, money) that operate in transactions.
CREATE PROC usp_WithdrawMoney(
	@AccountId INT,
	@MoneyForWithdraw MONEY
)
AS
	UPDATE Accounts 
	SET 
	Balance  = CASE WHEN Balance - @MoneyForWithdraw < 0 
	THEN Balance
	 ELSE Balance - @MoneyForWithdraw END
	WHERE Id = @AccountId
GO

EXEC usp_WithdrawMoney 1, 4000
GO

CREATE PROC usp_DepositMoney(
	@AccountId INT,
	@MoneyForDeposit MONEY
)
AS
	UPDATE Accounts
	SET Balance = Balance + @MoneyForDeposit
	WHERE Id = @AccountId
GO

EXEC usp_DepositMoney 1, 300
GO


-- Task 06. table – Logs(LogID, AccountID, OldSum, NewSum).
CREATE TABLE Logs(
Id int IDENTITY PRIMARY KEY,
AccountId int NOT NULL,
OldSum money NOT NULL,
NewSum money NOT NULL
)
GO

CREATE TRIGGER trg_Accounts_Change 
	ON Accounts
	AFTER UPDATE
AS
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT 
		i.Id, 
		d.Balance, 
		i.Balance 
	FROM inserted as i, 
		deleted as d
GO

EXEC usp_DepositMoney 1, 200
GO

-- Task 07. function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's 
--names that are comprised of given set of letters.
USE TelerikAcademy
GO
CREATE FUNCTION ufn_SpecificNames()
	RETURNS @ResTable TABLE(
		Name varchar(40)
	)
AS
BEGIN
	INSERT INTO @ResTable
	SELECT FirstName FROM Employees
	WHERE FirstName NOT LIKE '%[^oistmiah]%'
	UNION ALL
	SELECT LastName FROM Employees
	WHERE LastName NOT LIKE '%[^oistmiah]%'
	UNION ALL
	SELECT MiddleName FROM Employees 
	WHERE MiddleName NOT LIKE '%[^oistmiah]%'
	UNION ALL
	SELECT Name FROM Towns
	WHERE Name NOT LIKE '%[^oistmiah]%'
	RETURN
END
GO

