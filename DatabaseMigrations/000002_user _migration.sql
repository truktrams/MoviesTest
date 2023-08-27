DECLARE @dbVersion AS INT = (SELECT mif_CurrentVersion FROM sysMigrationInfo)
DECLARE @migrationVersion AS INT = 2

IF (@dbVersion = @migrationVersion-1)
BEGIN

	-- ########################################################################
	-- TABLES
	-- ########################################################################

	CREATE TABLE tblUser (
	    usr_Id INT IDENTITY(1,1) NOT NULL,
		usr_FirstName NVARCHAR(128) NULL,
		usr_LastName NVARCHAR(128) NULL,
		usr_Login NVARCHAR(64) NOT NULL,
		usr_PasswordHash NVARCHAR(MAX) NOT NULL,
		usr_Email NVARCHAR(128) NULL,
		usr_Phone NVARCHAR(32) NULL,
		usr_IsActive BIT NOT NULL,
		___EntityState NVARCHAR(8) NOT NULL DEFAULT 'A',
		CONSTRAINT PK_tblUser PRIMARY KEY (usr_Id),
		CONSTRAINT UQ_tblUser UNIQUE (usr_Login)
	)
	

	UPDATE sysMigrationInfo SET mif_CurrentVersion = @migrationVersion;
	
	DECLARE @successMessage AS NVARCHAR(512) = CHAR(13) + 'Successfully migrated to version: ' + CAST(@migrationVersion AS NVARCHAR(512))
	PRINT @successMessage

END
GO

