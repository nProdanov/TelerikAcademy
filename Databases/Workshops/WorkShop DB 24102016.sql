USE NORTHWND
GO

CREATE TABLE Cities(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(50) NOT NULL
)

INSERT INTO Cities (Name)
SELECT City FROM Employees
WHERE City IS NOT NULL
UNION 
SELECT City FROM Suppliers
WHERE City IS NOT NULL
UNION 
SELECT City FROM Customers
WHERE City IS NOT NULL

ALTER TABLE Employees
ADD CityId INT FOREIGN KEY REFERENCES Cities(Id)

ALTER TABLE Suppliers
ADD CityId INT FOREIGN KEY REFERENCES Cities(Id)

ALTER TABLE Customers 
ADD CityId INT FOREIGN KEY REFERENCES Cities(Id)

UPDATE e
SET e.CityId = c.Id
FROM Employees as e
JOIN Cities as c
ON e.City = c.Name

UPDATE s
SET s.CityId = c.Id
FROM Suppliers as s
JOIN Cities as c
ON s.City = c.Name

UPDATE cus
SET cus.CityId = c.Id
FROM Customers  as cus
JOIN Cities as c
ON cus.City = c.Name

ALTER TABLE Cities
ADD UNIQUE (Name)

INSERT INTO Cities
SELECT DISTINCT ShipCity FROM Orders
WHERE ShipCity NOT IN (SELECT Name FROM Cities)

ALTER TABLE Orders
ADD CityId INT FOREIGN KEY REFERENCES Cities(Id)

EXEC sp_RENAME 'TableName.OldColumnName' , 'NewColumnName', 'COLUMN'

UPDATE o
SET o.ShipCityId = c.Id
FROM Orders as o
JOIN Cities as c
ON o.ShipCity = c.Name

ALTER TABLE Orders
DROP COLUMN ShipCity

CREATE TABLE Countries(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(50) UNIQUE NOT NULL
)

ALTER TABLE Cities
ADD CountryId INT FOREIGN KEY REFERENCES Cities(Id)

INSERT INTO Countries
SELECT Country FROM Employees
WHERE Country IS NOT NULL
UNION
SELECT Country FROM Suppliers 
WHERE Country IS NOT NULL
UNION
SELECT ShipCountry FROM Orders 
WHERE ShipCountry IS NOT NULL
SELECT Country FROM Customers
WHERE Country IS NOT NULL

UPDATE c
SET c.CountryId = coun.Id
FROM Cities as c
JOIN Orders as o
ON c.Id = o.ShipCityId
JOIN Countries as coun
ON coun.Name = o.ShipCountry
WHERE c.CountryId IS NULL

UPDATE c
SET c.CountryId = coun.Id
FROM Cities as c
JOIN Customers as cust
ON c.Id = cust.CityId
JOIN Countries as coun
ON coun.Name = cust.Country
WHERE c.CountryId IS NULL

UPDATE c
SET c.CountryId = coun.Id
FROM Cities as c
JOIN Employees as e
ON c.Id = e.CityId
JOIN Countries as coun
ON coun.Name = e.Country
WHERE c.CountryId IS NULL

UPDATE c
SET c.CountryId = coun.Id
FROM Cities as c
JOIN Suppliers as s
ON c.Id = s.CityId
JOIN Countries as coun
ON coun.Name = s.Country
WHERE c.CountryId IS NULL

DROP INDEX Customers.City

ALTER TABLE Employees
DROP COLUMN City

ALTER TABLE Customers 
DROP COLUMN City

ALTER TABLE Suppliers
DROP COLUMN City

ALTER TABLE Orders
DROP COLUMN ShipCity

ALTER TABLE Employees
DROP COLUMN Country

ALTER TABLE Customers 
DROP COLUMN Country

ALTER TABLE Suppliers
DROP COLUMN Country

ALTER TABLE Orders
DROP COLUMN ShipCountry

