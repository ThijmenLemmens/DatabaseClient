CREATE DATABASE CarDatabase;
GO
USE CarDatabase;
GO

-- Create Headquarters table
CREATE TABLE tblHeadquarters (
    ID INT PRIMARY KEY IDENTITY(1,1),
    HeadquartersCity NVARCHAR(100) NOT NULL,
    HeadquartersCountry NVARCHAR(100) NOT NULL
);

-- Create CarCompany table
CREATE TABLE tblCarCompany (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FK_Headquarters INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Logo VARBINARY(MAX) NULL,
    CONSTRAINT FK_CarCompany_Headquarters FOREIGN KEY (FK_Headquarters)
        REFERENCES tblHeadquarters(ID)
        ON DELETE CASCADE
);

-- Create Car table
CREATE TABLE tblCar (
    ID INT PRIMARY KEY IDENTITY(1,1),
    FK_CarCompany INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    PK INT NOT NULL,
    CONSTRAINT FK_Car_CarCompany FOREIGN KEY (FK_CarCompany)
        REFERENCES tblCarCompany(ID)
        ON DELETE CASCADE
);
