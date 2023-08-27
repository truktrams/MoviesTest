IF NOT EXISTS(SELECT * FROM sys.databases WHERE Name = N'MoviesTestDb')
BEGIN
    CREATE DATABASE MoviesTestDb;
END
GO

USE MoviesTestDb;

IF NOT EXISTS(SELECT * FROM sys.Tables WHERE Name = N'sysMigrationInfo' AND TYPE = N'U')
BEGIN
    CREATE TABLE sysMigrationInfo (
        mif_Id INT NOT NULL,
        mif_CurrentVersion BIGINT NOT NULL,
    );

    INSERT INTO sysMigrationInfo (mif_Id, mif_CurrentVersion) VALUES (0, 0);
END
GO

