
USE CarDatabase;
GO

-- Country

CREATE PROCEDURE sp_CreateCountry
    @Name NVARCHAR(100),
    @NewId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO tblCountry (Name)
    VALUES (@Name);

    SET @NewId = SCOPE_IDENTITY();
END;
GO

CREATE PROCEDURE sp_GetAllCountries
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM 
        tblCountry
    ORDER BY 
        Name;
END;
GO

CREATE PROCEDURE sp_GetCountryByName
    @Name NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM 
        tblCountry
    WHERE 
        Name = @Name;
END;
GO

-- Headquaters

CREATE PROCEDURE sp_CreateHeadquater
    @City NVARCHAR(100),
    @FkCountry NVARCHAR(100),
    @NewId INT OUTPUT
AS
BEGIN
    INSERT INTO tblHeadquarters (City, FK_Country)
    VALUES (@City, @FkCountry);

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
        City; 
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

CREATE PROCEDURE sp_GetCarCompanyById
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        *
    FROM 
        tblCarCompany
    WHERE 
        ID = @ID;
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