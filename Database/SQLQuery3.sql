-- Drop sp_CreateHeadquater if it exists
IF OBJECT_ID('sp_CreateHeadquater', 'P') IS NOT NULL
    DROP PROCEDURE sp_CreateHeadquater;
GO

-- Drop sp_GetAllHeadquaters if it exists
IF OBJECT_ID('sp_GetAllHeadquaters', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllHeadquaters;
GO

-- Drop sp_CreateCarCompany if it exists
IF OBJECT_ID('sp_CreateCarCompany', 'P') IS NOT NULL
    DROP PROCEDURE sp_CreateCarCompany;
GO

-- Drop sp_GetAllCarCompanys if it exists
IF OBJECT_ID('sp_GetAllCarCompanys', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllCarCompanys;
GO
