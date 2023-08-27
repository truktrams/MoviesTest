DECLARE @dbVersion AS INT = (SELECT mif_CurrentVersion FROM sysMigrationInfo)
DECLARE @migrationVersion AS INT = 5

IF (@dbVersion = @migrationVersion-1)
BEGIN
	
	-- ########################################################################
	-- ENUMERATIONS
	-- ########################################################################
	
	CREATE TABLE enmReservationState (
	    rst_Code NVARCHAR(8) NOT NULL,
		rst_Title NVARCHAR(128) NOT NULL,
		CONSTRAINT PK_enmReservationState PRIMARY KEY (rst_Code)
	)

	-- ########################################################################
	-- TABLES
	-- ########################################################################
	
	CREATE TABLE tblReservation (
	    rsv_Id INT IDENTITY(1,1) NOT NULL,
		rsv_ReservationStateCode NVARCHAR(8) NOT NULL,
		rsv_UserId INT NOT NULL,
		rsv_TheaterId INT NOT NULL,
		rsv_TheaterShowTimeId INT NOT NULL,
		rsv_ReservedAt DATETIMEOFFSET NOT NULL,
		rsv_ApprovalKey UNIQUEIDENTIFIER NULL,
		___EntityState NVARCHAR(8) NOT NULL DEFAULT 'A',
		CONSTRAINT PK_tblReservation PRIMARY KEY (rsv_Id),
		CONSTRAINT FK_tblReservation_TO_tblUser FOREIGN KEY (rsv_UserId) REFERENCES tblUser(usr_Id),
		CONSTRAINT FK_tblReservation_TO_tblTheaterShowTime FOREIGN KEY (rsv_TheaterShowTimeId) REFERENCES tblTheaterShowTime(sht_Id),
		CONSTRAINT FK_tblReservation_TO_tblTheater FOREIGN KEY (rsv_TheaterId) REFERENCES tblTheater(tht_Id)
	)
	
	CREATE TABLE tblTheaterSeatReservation (
	    tsr_Id INT IDENTITY(1,1) NOT NULL,
		tsr_TheaterSeatId INT NOT NULL,
		tsr_ReservationId INT NOT NULL,
		tsr_TheaterShowTimeId INT NOT NULL,
		___EntityState NVARCHAR(8) NOT NULL DEFAULT 'A',
		CONSTRAINT PK_tblTheaterSeatReservation PRIMARY KEY (tsr_Id),
		CONSTRAINT FK_tblTheaterSeatReservation_TO_tblReservation FOREIGN KEY (tsr_ReservationId) REFERENCES tblReservation(rsv_Id),
		CONSTRAINT FK_tblTheaterSeatReservation_TO_tblTheaterSeat FOREIGN KEY (tsr_TheaterSeatId) REFERENCES tblTheaterSeat(ths_Id)
	)

	-- ########################################################################
	-- DATA
	-- ########################################################################
	
	INSERT INTO dbo.enmReservationState (rst_Code, rst_Title) VALUES ('PA', 'Pending Approval');
	INSERT INTO dbo.enmReservationState (rst_Code, rst_Title) VALUES ('AP', 'Approved');
	INSERT INTO dbo.enmReservationState (rst_Code, rst_Title) VALUES ('EX', 'Expired');
			

	UPDATE sysMigrationInfo SET mif_CurrentVersion = @migrationVersion;
	
	DECLARE @successMessage AS NVARCHAR(512) = CHAR(13) + 'Successfully migrated to version: ' + CAST(@migrationVersion AS NVARCHAR(512))
	PRINT @successMessage

END
GO

