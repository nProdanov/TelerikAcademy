USE TelerikAcademy

-- Task 04.
SELECT * FROM Departments

-- Task 05.
SELECT Name FROM Departments

-- Task 06.
SELECT FirstName, Salary FROM Employees

-- Task 07.
SELECT FirstName + ' ' + LastName as [Full Name] FROM Employees

-- Task 08.
SELECT FirstName + '.' + LastName + '@telerik.com' as [Email] 
FROM Employees

-- Task 09.
SELECT DISTINCT Salary
FROM Employees

-- Task 10.
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

-- Task 11.
SELECT FirstName, LastName
FROM Employees
WHERE (lower(FirstName)) LIKE 'sa%'

-- Task 12.
SELECT FirstName, LastName 
FROM Employees
WHERE (lower(LastName)) LIKE '%ei%'

-- Task 13.
SELECT FirstName, Salary 
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
ORDER BY Salary

-- Task 14.
SELECT FirstName, Salary 
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

-- Task 15.
SELECT FirstName, LastName 
FROM Employees
WHERE ManagerID IS NULL

-- Task 16.
SELECT FirstName, Salary 
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- Task 17.
SELECT TOP 5 FirstName, Salary 
FROM Employees
ORDER BY Salary DESC

-- Task 18.
SELECT e.FirstName, a.AddressText
FROM Employees as e
JOIN Addresses as a
ON e.AddressID = a.AddressID

-- Task 19.
SELECT e.FirstName, a.AddressText
FROM Employees as e,
Addresses as a
WHERE e.AddressID = a.AddressID

-- Task 20.
SELECT e.FirstName, e.ManagerID, m.FirstName, m.EmployeeID 
FROM Employees as e
JOIN Employees as m
ON e.ManagerID = m.EmployeeID

-- Task 21.
SELECT e.FirstName as [Employe], a.AddressText, m.FirstName as [Manager] FROM Employees as e
JOIN Addresses as a
ON e.AddressID = a.AddressID
JOIN Employees as m
ON e.ManagerID = m.EmployeeID

-- Task 22.
SELECT Name FROM Departments 
UNION
SELECT Name FROM Towns

-- Task 23.
SELECT e.FirstName as [Employe], m.FirstName[Manager] FROM Employees as e
LEFT OUTER JOIN Employees as m
ON e.ManagerID = m.EmployeeID

-- Task 23.
SELECT e.FirstName as [Employe], m.FirstName[Manager] FROM Employees as e
RIGHT OUTER JOIN Employees as m
ON e.ManagerID = m.EmployeeID

-- Task 24.
SELECT FirstName, d.Name, HireDate 
FROM Employees as e,
Departments as d
WHERE e.DepartmentID = d.DepartmentID AND 
d.Name IN ('Sales', 'Finance')
