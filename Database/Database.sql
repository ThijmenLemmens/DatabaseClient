CREATE DATABASE CarDatabase;
GO

USE CarDatabase;
GO

-- Countries
CREATE TABLE tblCountry (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- Headquarters
CREATE TABLE tblHeadquarters (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    City NVARCHAR(100) NOT NULL,
    FK_Country INT NOT NULL,
    FOREIGN KEY (FK_Country) REFERENCES tblCountry(ID)
);

-- Car Companies
CREATE TABLE tblCarCompany (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FK_Headquarters INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Logo VARBINARY(MAX) NULL,
    FOREIGN KEY (FK_Headquarters) REFERENCES tblHeadquarters(ID)
);

-- Cars
CREATE TABLE tblCar (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    FK_CarCompany INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    PK INT NOT NULL,
    FOREIGN KEY (FK_CarCompany) REFERENCES tblCarCompany(ID)
);

INSERT INTO tblCountry (Name) VALUES
(N'Duitsland'),
(N'Engeland'),
(N'Japan'),
(N'Verenigde Staten'),
(N'Italië'),
(N'Frankrijk');

INSERT INTO tblHeadquarters (City, FK_Country) VALUES
(N'Gaydon', 2),
(N'Ingolstadt', 1),
(N'München', 1),
(N'Detroit', 4),
(N'Auburn Hills', 4),
(N'Torino', 5),
(N'Dearborn', 4),
(N'Sant’Agata Bolognese', 5),
(N'Aichi', 3),
(N'Norfolk', 2),
(N'Hiroshima', 3),
(N'Stuttgart', 1),
(N'Tokio', 3),
(N'Zuffenhausen', 1),
(N'Parijs', 6),
(N'Gunma', 3),
(N'Wolfsburg', 1);

INSERT INTO tblCarCompany (FK_Headquarters, Name, Logo) VALUES
(1, N'Aston Martin', NULL),
(2, N'Audi', NULL),
(3, N'BMW', NULL),
(4, N'Cadillac', NULL),
(5, N'Chevrolet', NULL),
(6, N'Dodge', NULL),
(7, N'Fiat', NULL),
(8, N'Ford', NULL),
(9, N'Lamborghini', NULL),
(10, N'Lexus', NULL),
(11, N'Lotus', NULL),
(12, N'Mazda', NULL),
(13, N'Mercedes-Benz', NULL),
(14, N'Mitsubishi', NULL),
(4, N'Pontiac', NULL),
(15, N'Porsche', NULL),
(16, N'Renault', NULL),
(17, N'Subaru', NULL),
(13, N'Toyota', NULL),
(4, N'Vauxhall', NULL),
(17, N'Volkswagen', NULL);

INSERT INTO tblCar (FK_CarCompany, Name, PK) VALUES
(1, N'DB9', 455),
(2, N'TT 3.2 quattro', 340),
(2, N'A3 3.2 quattro', 344),
(2, N'A4 3.2 FSI quattro', 420),
(3, N'M3 GTR (E46)', 420),
(4, N'CTS', 420),
(5, N'Cobalt SS', 260),
(5, N'Corvette C5', 350),
(5, N'Corvette C6', 400),
(5, N'Camaro SS', 415),
(5, N'Corvette C6R', 470),
(6, N'Viper SRT-10', 640),
(7, N'Punto', 134),
(8, N'GT', 500),
(9, N'Gallardo', 560),
(9, N'Murciélago', 641),
(10, N'IS 300', 311),
(11, N'Elise', 220),
(12, N'RX-8', 250),
(12, N'RX-7', 255),
(13, N'SL 500', 375),
(13, N'CLK 500', 385),
(13, N'CLS55 AMG', 476),
(13, N'SL65 AMG', 520),
(13, N'SLR McLaren', 650),
(14, N'Eclipse', 195),
(14, N'Lancer Evolution VIII', 302),
(15, N'GTO', 400),
(16, N'Cayman S', 320),
(16, N'911 Carrera S', 400),
(16, N'911 GT3', 450),
(16, N'911 GT2', 523),
(16, N'911 Turbo S', 523),
(16, N'Carrera GT', 612),
(17, N'Clio V6', 255),
(18, N'Impreza WRX', 280),
(19, N'Supra', 330),
(20, N'Monaro VXR', 507),
(21, N'Golf GTI', 250);
