USE master;
GO

IF DB_ID('StudentDB2') IS NOT NULL
BEGIN
    ALTER DATABASE StudentDB2 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE StudentDB2;
END
GO

CREATE DATABASE StudentDB2;
GO

USE StudentDB2;
GO

CREATE TABLE dbo.Student
(
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Age INT NOT NULL CHECK (Age > 0),
    Email VARCHAR(100)
);
GO

INSERT INTO dbo.Student (FirstName, LastName, Age, Email)
VALUES
('Isha', 'Sharma', 20, 'isha@gmail.com'),
('Rahul', 'Patil', 22, 'rahul@gmail.com'),
('Amit', 'Joshi', 21, 'amit@gmail.com');
GO

SELECT * FROM dbo.Student;
GO

SELECT *
FROM dbo.Student
WHERE Age >= 21
ORDER BY LastName ASC;
GO

UPDATE dbo.Student
SET Age = 25
WHERE FirstName = 'Rahul';
GO

SELECT * FROM dbo.Student;
GO

DELETE FROM dbo.Student
WHERE FirstName = 'Amit';
GO

SELECT * FROM dbo.Student;
GO
