DECLARE @dbVersion AS INT = (SELECT mif_CurrentVersion FROM sysMigrationInfo)
DECLARE @migrationVersion AS INT = 3

IF (@dbVersion = @migrationVersion-1)
BEGIN

	-- ########################################################################
	-- TABLES
	-- ########################################################################

	CREATE TABLE tblGenre (
	    gnr_Code NVARCHAR(128) NOT NULL,
		gnr_Title NVARCHAR(128) NOT NULL,
		___EntityState NVARCHAR(8) NOT NULL DEFAULT 'A',
		CONSTRAINT PK_tblGenre PRIMARY KEY (gnr_Code)
	)

	CREATE TABLE tblMovie (
	    mov_Id INT IDENTITY(1,1) NOT NULL,
	    mov_GenreCode NVARCHAR(128) NOT NULL,
		mov_Title NVARCHAR(128) NOT NULL,
		mov_Year INT NOT NULL,
		mov_Rating DECIMAL NOT NULL,
		mov_Description NVARCHAR(MAX) NOT NULL,
		mov_DurationTicks BIGINT NOT NULL,
		___EntityState NVARCHAR(8) NOT NULL DEFAULT 'A',
		CONSTRAINT PK_tblMovie PRIMARY KEY (mov_Id),
		CONSTRAINT FK_tblMovie_TO_tblGenre FOREIGN KEY (mov_GenreCode) REFERENCES tblGenre(gnr_Code)
	)
		

	-- ########################################################################
	-- DATA
	-- ########################################################################
	
	INSERT INTO dbo.tblGenre (gnr_Code, gnr_Title) VALUES ('HORROR', 'Horror');
	INSERT INTO dbo.tblGenre (gnr_Code, gnr_Title) VALUES ('ACTION', 'Action');
	INSERT INTO dbo.tblGenre (gnr_Code, gnr_Title) VALUES ('SCI-FI', 'Sci-Fi');
	INSERT INTO dbo.tblGenre (gnr_Code, gnr_Title) VALUES ('DRAMA', 'DRAMA');
	INSERT INTO dbo.tblGenre (gnr_Code, gnr_Title) VALUES ('CARTOON', 'Cartoon');	
					  
					  
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('HORROR', 'The Last Voyage of the Demeter ', 2023, 6.4, 'Film about The Last Voyage of the Demeter.', 70800000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('ACTION', 'Blue Beetle', 2023, 6.7, 'Film about Blue Beatle.', 73200000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('ACTION', 'Guardians of the Galaxy Vol. 3', 2023, 8.5, 'Film about Guardians of the Galaxy Vol. 3.', 90000000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('ACTION', 'The Witcher', 2019, 8.0, 'Film about The Witcher.', 36000000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('SCI-FI', 'Ahsoka', 2023, 8.4, 'Film about Ahsoka.', 80000000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('SCI-FI', 'Meg 2: The Trench ', 2023, 5.4, 'Film about Meg 2: The Trench.', 69600000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('SCI-FI', 'Black Mirror', 2011, 8.7, 'Film about Black Mirror.', 36000000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('DRAMA', 'Only Murders in the Building', 2021, 8.1, 'Film about Only Murders in the Building.', 18000000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('DRAMA', 'The Bear', 2022, 8.5, 'Film about The Bear.', 18000000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('CARTOON', 'Spider-Man: Across the Spider-Verse', 2023, 8.8, 'Film about Spider-Man: Across the Spider-Verse.', 84000000000);
	INSERT INTO dbo.tblMovie (mov_GenreCode, mov_Title, mov_Year, mov_Rating, mov_Description, mov_DurationTicks)
	                  VALUES ('CARTOON', 'Teenage Mutant Ninja Turtles: Mutant Mayhem', 2023, 7.5, 'Film about Teenage Mutant Ninja Turtles: Mutant Mayhem.', 59400000000);
					  
		
	UPDATE sysMigrationInfo SET mif_CurrentVersion = @migrationVersion;
	
	DECLARE @successMessage AS NVARCHAR(512) = CHAR(13) + 'Successfully migrated to version: ' + CAST(@migrationVersion AS NVARCHAR(512))
	PRINT @successMessage

END
GO

