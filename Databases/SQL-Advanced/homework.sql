USE TelerikAcademy

-- Task 01. find the names and salaries of the employees that take the minimal salary in the company.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary =
  (SELECT MIN(Salary) FROM Employees)

-- Task 02. find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 
  (SELECT MIN(Salary) FROM Employees) * 1.1
  ORDER BY Salary

-- Task 03. find the full name, salary and department of the employees that take the minimal salary in their department.

 SELECT FirstName, LastName, d.Name as Department, Salary
FROM Employees e,
Departments as d
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID) AND d.DepartmentID = e.DepartmentID
ORDER BY d.Name

-- Task 04. find the average salary in the department #1.

SELECT AVG(Salary) as [AVG Salary Dept 1]
FROM Employees
WHERE DepartmentID = 1

-- Task 05. find the average salary in the "Sales" department.

SELECT AVG(Salary) as [AVG Salary Dept 1]
FROM Employees as e
WHERE e.DepartmentID = 
(SELECT DepartmentID FROM Departments
WHERE Name = 'Sales')

-- Task 05.
SELECT AVG(Salary)
FROM Employees as e,
Departments as d
WHERE e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'

-- Task 06.find the number of employees in the "Sales" department.

SELECT COUNT(EmployeeID) as [Number Of Employes in Sales Dept]
FROM Employees as e
WHERE e.DepartmentID = 
(SELECT DepartmentID FROM Departments
WHERE Name = 'Sales')

-- Task 07. find the number of all employees that have manager.

SELECT COUNT(EmployeeID) as [Number of Employees with manager]FROM Employees
WHERE ManagerID IS NOT NULL

-- Task 08.find the number of all employees that have no manager.

SELECT COUNT(EmployeeID) as [Number of Employees with manager]FROM Employees
WHERE ManagerID IS NULL

-- Task 09.find all departments and the average salary for each of them.
SELECT d.Name, MIN(e.Salary) 
FROM Employees as e
JOIN Departments as d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- Task 10.find the count of all employees in each department and for each town.

SELECT d.Name, t.Name, COUNT(*)
from Employees as e
JOIN Addresses as a
ON e.AddressID = a.AddressID
JOIN Towns as t
ON a.TownID = t.TownID
JOIN Departments as d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, t.Name
ORDER BY d.Name

-- Task 11.find all managers that have exactly 5 employees. Display their first name and last name
SELECT m.FirstName, m.LastName
FROM Employees as e
JOIN Employees as m
ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.FirstName) = 5

-- Task 12.find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

SELECT e.FirstName, e.LastName, ISNULL(m.FirstName, 'No manager')
FROM Employees as e
LEFT OUTER JOIN Employees as m
ON e.ManagerID = m.EmployeeID

-- Task 13.find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT e.FirstName, e.LastName
FROM Employees as e
WHERE LEN(e.LastName) = 5

-- Task 14.display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".

SELECT CONVERT(varchar(24), GETDATE(), 113)  -- Europe default + millisec

-- 15.Write a SQL statement to create a table Users.
CREATE TABLE Users(
UserID int IDENTITY,
UserName varchar(30) NOT NULL UNIQUE,
Password varchar(30),
FullName nvarchar(70) NOT NULL,
LastLogin smalldatetime,
CONSTRAINT PK_Users PRIMARY KEY(UserID),
CHECK (LEN(Password)>4)
)

-- Task 16. - Create view that displays the users from the Users 
-- table that have been in the system today.
CREATE VIEW [Users Today] AS
SELECT UserName, FullName FROM Users
WHERE
DAY(LastLogin) = DAY(GETDATE()) AND
YEAR(LastLogin) = YEAR(GETDATE()) AND
MONTH(LastLogin) = MONTH(GETDATE())

-- 17. - create a table Groups
CREATE TABLE Groups (
GroupID int IDENTITY,
Name nvarchar(50) NOT NULL UNIQUE,
CONSTRAINT PK_Groups PRIMARY KEY (GroupID)
)

-- Task 18. - add a column GroupID to the table Users.
ALTER TABLE Users
ADD GroupID int

-- After populate GroupID column 

ALTER TABLE Users
ALTER COLUMN GroupID int NOT NULL

-- Add Foreign key
ALTER TABLE Users
ADD FOREIGN KEY (GroupID)
REFERENCES Groups(GroupID)

-- 19. insert several records in the Users and Groups tables
INSERT INTO Users (UserName, Password, FullName, LastLogin, GroupID)
VALUES ('ivan95', 'secret', 'Ivan Lilov', '2016-10-21',2),
('dean', '12345', 'Dean Trendy', '2016-10-21',1),
('gosho', 'malukgosho', 'Lil Gosho', '2016-10-01',3)

INSERT INTO Groups (Name)
VALUES ('Cool Group'),
('Smotana Group'),
('Nqma takava Group')

-- Task 20. update some of the records in the Users and Groups tables.
UPDATE Users
SET FullName = 'Georgi Nikolov'
WHERE UserName = 'gosho'

UPDATE Groups
SET Name = 'Smart one'
WHERE Name = 'Smotana Group'

-- Task 21. delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE UserName = 'gosho'

DELETE FROM Groups
WHERE Name = 'Nqma takava Group'

-- Task 22.insert in the Users table the names of 
--all employees from the Employees table.
INSERT INTO Users (UserName, Password, FullName, GroupID)
SELECT 
LOWER(RIGHT(FirstName, 2)) + LOWER(LastName), 
LOWER(FirstName) + '12345',
FirstName + ' ' + LastName,
1
 FROM Employees

 -- Task 23. changes the password to NULL for all users that have 
 --not been in the system since 10.03.2010.
 UPDATE Users
 SET Users.Password = NULL
 WHERE LastLogin < '2010-03-10'


 -- Task 24. deletes all users without passwords 
 DELETE FROM Users
 WHERE Password IS NULL

 -- Task 25. display the average employee salary by department and job title.
 SELECT d.Name, JobTitle, AVG(Salary) as [Average Salary] 
 FROM Employees as e
 JOIN Departments as d
 ON e.DepartmentID = d.DepartmentID
 GROUP BY d.Name, JobTitle
 ORDER BY d.Name

 -- Task 26. minimal employee salary by department and job title 
 --along with the name of some of the employees that take it.
 SELECT d.Name, JobTitle, MIN(Salary) as [Min Salary], e.FirstName
 FROM Employees as e
 JOIN Departments as d
 ON e.DepartmentID = d.DepartmentID
 GROUP BY d.Name, JobTitle, e.FirstName
 ORDER BY d.Name, e.FirstName

 -- Task 27. display the town where maximal number of employees work.
 SElECT top 1 t.Name as [Town], COUNT(e.FirstName) as [Number of Employees]
 FROM Employees as e
 JOIN Addresses as a
 ON e.AddressID = a.AddressID
 JOIN Towns as t
 ON a.TownID = t.TownID
 GROUP BY t.Name
 ORDER BY COUNT(e.FirstName) DESC

 -- Task 28.display the number of managers from each town.
 SELECT t.Name as [Town], 
 COUNT(m.EmployeeID) as [Managers Count]
 FROM Employees as e
 RIGHT JOIN Employees as m
 ON e.ManagerID = m.EmployeeID
 JOIN Addresses as a
 ON e.AddressID = a.AddressID
 JOIN Towns as t
 ON a.TownID = t.TownID
 WHERE e.FirstName IS NOT NULL
 GROUP BY t.Name

-- Task 29. create table WorkHours to store work 
----reports for each employee (employee id, date, task, hours, comments).
--Define a table WorkHoursLogs to track all 
----changes in the WorkHours table with triggers
 CREATE TABLE WorkHours(
 WorkHourID int IDENTITY PRIMARY KEY,
 EmployeeId int NOT NULL,
 Date smalldatetime NOT NULL,
 Task nvarchar(50) NOT NULL,
 Hours int NOT NULL,
 Comments nvarchar(100),
 CONSTRAINT FK_WorkHours_Employees
	FOREIGN KEY (EmployeeID)
	REFERENCES Employees(EmployeeID)
 )

 CREATE TABLE ReportsLogs(
 ReportsLogID int IDENTITY PRIMARY KEY,
 OldData nvarchar(100),
 NewData nvarChar(100),
 Date smalldatetime NOT NULL,
 Command varchar(10)
 )
 GO

CREATE TRIGGER trg_WorkHours_Insert ON WorkHours 
AFTER INSERT
AS 
INSERT INTO ReportsLogs(OldData, NewData, Date, Command)
      SELECT NULL, 
	  'Employee :' + CONVERT(VARCHAR(19),i.EmployeeId) + 
	  ' Task: ' +
	  i.Task + 
	  ' Comments: ' +  
	  i.Comments + 
	  ' Date: ' + 
	  CONVERT(VARCHAR(19), i.Date, 113),
	  GETDATE(),
	  'INSERT'
      FROM INSERTED as i
GO

CREATE TRIGGER trg_WorkHours_Update ON WorkHours 
AFTER UPDATE
AS 
INSERT INTO ReportsLogs(OldData, NewData, Date, Command)
      SELECT
	  'Employee :' + CONVERT(VARCHAR(19),d.EmployeeId) + 
	  ' Task: ' +
	  d.Task + 
	  ' Comments: ' +  
	  d.Comments + 
	  ' Date: ' + 
	  CONVERT(VARCHAR(19), d.Date, 113),

	  'Employee :' + CONVERT(VARCHAR(19),i.EmployeeId) + 
	  ' Task: ' +
	  i.Task + 
	  ' Comments: ' +  
	  i.Comments + 
	  ' Date: ' + 
	  CONVERT(VARCHAR(19), i.Date, 113),
	  GETDATE(),
	  'UPDATE'
      FROM inserted as i,
	  deleted as d
GO

CREATE TRIGGER trg_WorkHours_Delete ON WorkHours 
AFTER DELETE
AS 
INSERT INTO ReportsLogs(OldData, NewData, Date, Command)
      SELECT
	  'Employee :' + CONVERT(VARCHAR(19),d.EmployeeId) + 
	  ' Task: ' +
	  d.Task + 
	  ' Comments: ' +  
	  d.Comments + 
	  ' Date: ' + 
	  CONVERT(VARCHAR(19), d.Date, 113),
	  NULL,
	  GETDATE(),
	  'DELETE'
      FROM 
	  deleted as d
GO


-- Task 30. delete all employees from the 'Sales' department along with all 
--dependent records from the pother tables.
--At the end rollback the transaction.
BEGIN TRAN

-- DELETing
ALTER TABLE Employees NOCHECK CONSTRAINT all
ALTER TABLE Departments NOCHECK CONSTRAINT all
DELETE FROM Employees
WHERE DepartmentID = 
(SELECT DepartmentID 
FROM Departments 
WHERE Name = 'Sales')

-- ROllback
ROLLBACK TRAN

ALTER TABLE Employees CHECK CONSTRAINT all
ALTER TABLE Departments CHECK CONSTRAINT all

-- Task 31. drop the table EmployeesProjects.
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

-- Task 32. Find how to use temporary tables in SQL Server.
BEGIN TRAN
SELECT *  INTO  #TempEmployeesProjects
FROM EmployeesProjects

DROP TABLE EmployeesProjects

SELECT * INTO EmployeesPRojects
FROM #TempEmployeesProjects

ROLLBACK TRAN