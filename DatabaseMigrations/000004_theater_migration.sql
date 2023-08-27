DECLARE @dbVersion AS INT = (SELECT mif_CurrentVersion FROM sysMigrationInfo)
DECLARE @migrationVersion AS INT = 4

IF (@dbVersion = @migrationVersion-1)
BEGIN

	-- ########################################################################
	-- TABLES
	-- ########################################################################
	
	CREATE TABLE tblTheater (
	    tht_Id INT IDENTITY(1,1) NOT NULL,
		tht_Title NVARCHAR(128) NOT NULL,
		___EntityState NVARCHAR(8) NOT NULL DEFAULT 'A',
		CONSTRAINT PK_tblTheater PRIMARY KEY (tht_Id)
	)
	
	CREATE TABLE tblTheaterSeat (
	    ths_Id INT IDENTITY(1,1) NOT NULL,
	    ths_TheaterId INT NOT NULL,
		ths_Title NVARCHAR(128) NOT NULL,
		ths_SeatPrice DECIMAL(6,2) NOT NULL,
		___EntityState NVARCHAR(8) NOT NULL DEFAULT 'A',
		CONSTRAINT PK_tblTheaterSeat PRIMARY KEY (ths_Id),
		CONSTRAINT FK_tblTheaterSeat_TO_tblTheater FOREIGN KEY (ths_TheaterId) REFERENCES tblTheater(tht_Id)
	)
	
	CREATE TABLE tblTheaterShowTime (
	    sht_Id INT IDENTITY(1,1) NOT NULL,
	    sht_TheaterId INT NOT NULL,
	    sht_MovieId INT NOT NULL,
		sht_StartDateTimeUtc DATETIMEOFFSET NOT NULL,
		sht_EndDateTimeUtc DATETIMEOFFSET NOT NULL,
		sht_TicketPriceUsd DECIMAL(6,2) NOT NULL,
		___EntityState NVARCHAR(8) NOT NULL DEFAULT 'A',
		CONSTRAINT PK_tblTheaterShowTime PRIMARY KEY (sht_Id),
		CONSTRAINT FK_tblTheaterShowTime_TO_tblTheater FOREIGN KEY (sht_TheaterId) REFERENCES tblTheater(tht_Id),
		CONSTRAINT FK_tblTheaterShowTime_TO_tblMovie FOREIGN KEY (sht_MovieId) REFERENCES tblMovie(mov_Id)
	)

	-- ########################################################################
	-- DATA
	-- ########################################################################
	
	INSERT INTO dbo.tblTheater (tht_Title) VALUES ('Theater 1');
	INSERT INTO dbo.tblTheater (tht_Title) VALUES ('Theater 2');
	INSERT INTO dbo.tblTheater (tht_Title) VALUES ('Theater 3');
		
	
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 0', 10.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 1', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 2', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 3', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 4', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 5', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 6', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 7', 2.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 8', 2.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (1, 'Seat 9', 2.50);
	
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 0', 10.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 1', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 2', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 3', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 4', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 5', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 6', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 7', 2.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 8', 2.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (2, 'Seat 9', 2.50);
	
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 0', 10.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 1', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 2', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 3', 7.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 4', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 5', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 6', 5.00);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 7', 2.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 8', 2.50);
	INSERT INTO dbo.tblTheaterSeat (ths_TheaterId, ths_Title, ths_SeatPrice) VALUES (3, 'Seat 9', 2.50);
	
	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-01 08:00:00.000', '2023-09-01 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 4, '2023-09-01 10:00:00.000', '2023-09-01 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 6, '2023-09-01 12:00:00.000', '2023-09-01 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 1, '2023-09-01 14:00:00.000', '2023-09-01 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 3, '2023-09-01 16:00:00.000', '2023-09-01 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 5, '2023-09-01 18:00:00.000', '2023-09-01 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 1, '2023-09-02 08:00:00.000', '2023-09-02 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 4, '2023-09-02 10:00:00.000', '2023-09-02 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 6, '2023-09-02 12:00:00.000', '2023-09-02 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 4, '2023-09-02 14:00:00.000', '2023-09-02 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-02 16:00:00.000', '2023-09-02 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 1, '2023-09-02 18:00:00.000', '2023-09-02 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-03 08:00:00.000', '2023-09-03 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 3, '2023-09-03 10:00:00.000', '2023-09-03 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 3, '2023-09-03 12:00:00.000', '2023-09-03 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 1, '2023-09-03 14:00:00.000', '2023-09-03 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-03 16:00:00.000', '2023-09-03 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 5, '2023-09-03 18:00:00.000', '2023-09-03 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-04 08:00:00.000', '2023-09-04 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 4, '2023-09-04 10:00:00.000', '2023-09-04 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-04 12:00:00.000', '2023-09-04 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 1, '2023-09-04 14:00:00.000', '2023-09-04 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 6, '2023-09-04 16:00:00.000', '2023-09-04 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 8, '2023-09-04 18:00:00.000', '2023-09-04 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-05 08:00:00.000', '2023-09-05 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-05 10:00:00.000', '2023-09-05 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 6, '2023-09-05 12:00:00.000', '2023-09-05 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 4, '2023-09-05 14:00:00.000', '2023-09-05 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 1, '2023-09-05 16:00:00.000', '2023-09-05 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 7, '2023-09-05 18:00:00.000', '2023-09-05 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 1, '2023-09-06 08:00:00.000', '2023-09-06 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 4, '2023-09-06 10:00:00.000', '2023-09-06 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 3, '2023-09-06 12:00:00.000', '2023-09-06 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 1, '2023-09-06 14:00:00.000', '2023-09-06 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 5, '2023-09-06 16:00:00.000', '2023-09-06 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (1, 2, '2023-09-06 18:00:00.000', '2023-09-06 20:00:00.000', 25.00);
	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-01 08:00:00.000', '2023-09-01 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 4, '2023-09-01 10:00:00.000', '2023-09-01 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 6, '2023-09-01 12:00:00.000', '2023-09-01 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 1, '2023-09-01 14:00:00.000', '2023-09-01 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 3, '2023-09-01 16:00:00.000', '2023-09-01 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 5, '2023-09-01 18:00:00.000', '2023-09-01 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 1, '2023-09-02 08:00:00.000', '2023-09-02 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 4, '2023-09-02 10:00:00.000', '2023-09-02 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 6, '2023-09-02 12:00:00.000', '2023-09-02 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 4, '2023-09-02 14:00:00.000', '2023-09-02 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-02 16:00:00.000', '2023-09-02 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 1, '2023-09-02 18:00:00.000', '2023-09-02 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-03 08:00:00.000', '2023-09-03 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 3, '2023-09-03 10:00:00.000', '2023-09-03 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 3, '2023-09-03 12:00:00.000', '2023-09-03 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 1, '2023-09-03 14:00:00.000', '2023-09-03 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-03 16:00:00.000', '2023-09-03 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 5, '2023-09-03 18:00:00.000', '2023-09-03 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-04 08:00:00.000', '2023-09-04 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 4, '2023-09-04 10:00:00.000', '2023-09-04 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-04 12:00:00.000', '2023-09-04 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 1, '2023-09-04 14:00:00.000', '2023-09-04 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 6, '2023-09-04 16:00:00.000', '2023-09-04 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 8, '2023-09-04 18:00:00.000', '2023-09-04 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-05 08:00:00.000', '2023-09-05 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-05 10:00:00.000', '2023-09-05 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 6, '2023-09-05 12:00:00.000', '2023-09-05 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 4, '2023-09-05 14:00:00.000', '2023-09-05 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 1, '2023-09-05 16:00:00.000', '2023-09-05 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 7, '2023-09-05 18:00:00.000', '2023-09-05 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 1, '2023-09-06 08:00:00.000', '2023-09-06 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 4, '2023-09-06 10:00:00.000', '2023-09-06 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 3, '2023-09-06 12:00:00.000', '2023-09-06 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 1, '2023-09-06 14:00:00.000', '2023-09-06 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 5, '2023-09-06 16:00:00.000', '2023-09-06 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (2, 2, '2023-09-06 18:00:00.000', '2023-09-06 20:00:00.000', 25.00);
	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-01 08:00:00.000', '2023-09-01 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 4, '2023-09-01 10:00:00.000', '2023-09-01 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 6, '2023-09-01 12:00:00.000', '2023-09-01 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 1, '2023-09-01 14:00:00.000', '2023-09-01 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 3, '2023-09-01 16:00:00.000', '2023-09-01 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 5, '2023-09-01 18:00:00.000', '2023-09-01 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 1, '2023-09-02 08:00:00.000', '2023-09-02 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 4, '2023-09-02 10:00:00.000', '2023-09-02 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 6, '2023-09-02 12:00:00.000', '2023-09-02 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 4, '2023-09-02 14:00:00.000', '2023-09-02 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-02 16:00:00.000', '2023-09-02 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 1, '2023-09-02 18:00:00.000', '2023-09-02 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-03 08:00:00.000', '2023-09-03 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 3, '2023-09-03 10:00:00.000', '2023-09-03 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 3, '2023-09-03 12:00:00.000', '2023-09-03 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 1, '2023-09-03 14:00:00.000', '2023-09-03 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-03 16:00:00.000', '2023-09-03 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 5, '2023-09-03 18:00:00.000', '2023-09-03 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-04 08:00:00.000', '2023-09-04 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 4, '2023-09-04 10:00:00.000', '2023-09-04 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-04 12:00:00.000', '2023-09-04 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 1, '2023-09-04 14:00:00.000', '2023-09-04 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 6, '2023-09-04 16:00:00.000', '2023-09-04 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 8, '2023-09-04 18:00:00.000', '2023-09-04 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-05 08:00:00.000', '2023-09-05 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-05 10:00:00.000', '2023-09-05 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 6, '2023-09-05 12:00:00.000', '2023-09-05 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 4, '2023-09-05 14:00:00.000', '2023-09-05 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 1, '2023-09-05 16:00:00.000', '2023-09-05 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 7, '2023-09-05 18:00:00.000', '2023-09-05 20:00:00.000', 25.00);	
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 1, '2023-09-06 08:00:00.000', '2023-09-06 10:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 4, '2023-09-06 10:00:00.000', '2023-09-06 12:00:00.000', 40.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 3, '2023-09-06 12:00:00.000', '2023-09-06 14:00:00.000', 50.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 1, '2023-09-06 14:00:00.000', '2023-09-06 16:00:00.000', 35.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 5, '2023-09-06 16:00:00.000', '2023-09-06 18:00:00.000', 25.00);
	INSERT INTO dbo.tblTheaterShowTime (sht_TheaterId, sht_MovieId, sht_StartDateTimeUtc, sht_EndDateTimeUtc, sht_TicketPriceUsd) VALUES (3, 2, '2023-09-06 18:00:00.000', '2023-09-06 20:00:00.000', 25.00);
	

	UPDATE sysMigrationInfo SET mif_CurrentVersion = @migrationVersion;
	
	DECLARE @successMessage AS NVARCHAR(512) = CHAR(13) + 'Successfully migrated to version: ' + CAST(@migrationVersion AS NVARCHAR(512))
	PRINT @successMessage

END
GO

