Create Database Test

Use Test

CREATE TABLE Investors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(50) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Country NVARCHAR(100) NOT NULL
);

CREATE TABLE Funds (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE InvestorFunds (
    InvestorId INT NOT NULL,
    FundId INT NOT NULL,
    PRIMARY KEY (InvestorId, FundId),
    FOREIGN KEY (InvestorId) REFERENCES Investors(Id) ON DELETE CASCADE,
    FOREIGN KEY (FundId) REFERENCES Funds(Id) ON DELETE CASCADE
);

--1. Insert Investors

INSERT INTO Investors (Name, Phone, Email, Country)
VALUES 
('Keely Newman', '1-786-738-4711', 'in.magna@yahoo.com', 'USA'),
('Kimberly Maldonado', '(684) 842-2371', 'non.lacinia@outlook.org', 'Spain'),
('Sean Massey', '(548) 250-4693', 'pharetra.quisque.ac@outlook.edu', 'Ireland'),
('Nyssa Barr', '(673) 581-3597', 'odio@aol.couk', 'Canada');

--2. Insert Funds
INSERT INTO Funds (Name)
VALUES 
('Mauris LLP'),
('Nullam Velit Fund'),
('Ligula Aenean Fund'),
('Mauris Sit Amet Fund'),
('Ullamcorper Viverra Fund');

--3. Link Investors with Funds (InvestorFunds Table)

 --Keely Newman invested in "Mauris LLP" and "Nullam Velit Fund"
INSERT INTO InvestorFunds (InvestorId, FundId)
VALUES 
((SELECT Id FROM Investors WHERE Name = 'Keely Newman'), (SELECT Id FROM Funds WHERE Name = 'Mauris LLP')),
((SELECT Id FROM Investors WHERE Name = 'Keely Newman'), (SELECT Id FROM Funds WHERE Name = 'Nullam Velit Fund'));

-- Kimberly Maldonado invested in "Nullam Velit Fund"
INSERT INTO InvestorFunds (InvestorId, FundId)
VALUES 
((SELECT Id FROM Investors WHERE Name = 'Kimberly Maldonado'), (SELECT Id FROM Funds WHERE Name = 'Nullam Velit Fund'));

-- Sean Massey invested in "Mauris LLP", "Ligula Aenean Fund", and "Mauris Sit Amet Fund"
INSERT INTO InvestorFunds (InvestorId, FundId)
VALUES 
((SELECT Id FROM Investors WHERE Name = 'Sean Massey'), (SELECT Id FROM Funds WHERE Name = 'Mauris LLP')),
((SELECT Id FROM Investors WHERE Name = 'Sean Massey'), (SELECT Id FROM Funds WHERE Name = 'Ligula Aenean Fund')),
((SELECT Id FROM Investors WHERE Name = 'Sean Massey'), (SELECT Id FROM Funds WHERE Name = 'Mauris Sit Amet Fund'));

-- Nyssa Barr invested in "Ullamcorper Viverra Fund"
INSERT INTO InvestorFunds (InvestorId, FundId)
VALUES 
((SELECT Id FROM Investors WHERE Name = 'Nyssa Barr'), (SELECT Id FROM Funds WHERE Name = 'Ullamcorper Viverra Fund'));

