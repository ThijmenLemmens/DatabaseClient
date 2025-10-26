
USE CarDatabase;
GO

-- Headquaters

CREATE PROCEDURE sp_CreateHeadquater
    @City NVARCHAR(100),
    @Country NVARCHAR(100),
    @NewId INT OUTPUT
AS
BEGIN
    INSERT INTO tblHeadquarters (HeadquartersCity, HeadquartersCountry)
    VALUES (@City, @Country);

    SET @NewId = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE sp_GetAllHeadquaters
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM 
        tblHeadquarters
    ORDER BY 
        HeadquartersCity; 
END;
GO

-- Car Companys

CREATE PROCEDURE sp_CreateCarCompany
    @FkHeadquaters INT,
    @Name NVARCHAR(100),
    @Logo VARBINARY(MAX),
    @NewId INT OUTPUT
AS
BEGIN
    INSERT INTO tblCarCompany (FK_Headquarters, Name, Logo)
    VALUES (@FkHeadquaters, @Name, @Logo);

    SET @NewId = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE sp_GetAllCarCompanys
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM 
        tblCarCompany
    ORDER BY 
        Name; 
END;
GO

-- Car

CREATE PROCEDURE sp_CreateCar
    @Name NVARCHAR(100),
    @Pk int,
    @FkCarCompany int,
    @NewId INT OUTPUT
AS
BEGIN
    INSERT INTO tblCar (FK_CarCompany, Name, PK)
    VALUES (@FkCarCompany, @Name, @Pk);

    SET @NewId = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE sp_GetCarsByCompanyId
    @CarCompanyId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM 
        tblCar
    WHERE 
        FK_CarCompany = @CarCompanyId;
END;
GO