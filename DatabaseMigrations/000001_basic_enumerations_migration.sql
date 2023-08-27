DECLARE @dbVersion AS INT = (SELECT mif_CurrentVersion FROM sysMigrationInfo)
DECLARE @migrationVersion AS INT = 1

IF (@dbVersion = @migrationVersion-1)
BEGIN

	-- ########################################################################
	-- ENUMERATIONS
	-- ########################################################################

	CREATE TABLE enmEntityState (
		est_Code NVARCHAR(8) NOT NULL,
		est_Title NVARCHAR(128) NOT NULL,
		CONSTRAINT PK_enmEntityState PRIMARY KEY (est_Code)
	)

	INSERT INTO dbo.enmEntityState (est_Code, est_Title) VALUES ('A', 'Active');
	INSERT INTO dbo.enmEntityState (est_Code, est_Title) VALUES ('D', 'Deleted');
	

	UPDATE sysMigrationInfo SET mif_CurrentVersion = @migrationVersion;
	
	DECLARE @successMessage AS NVARCHAR(512) = CHAR(13) + 'Successfully migrated to version: ' + CAST(@migrationVersion AS NVARCHAR(512))
	PRINT @successMessage

END
GO

