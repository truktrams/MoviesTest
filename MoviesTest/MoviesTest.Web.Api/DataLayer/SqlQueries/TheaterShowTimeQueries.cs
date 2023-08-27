namespace MoviesTest.Web.Api.DataLayer.SqlQueries;

internal static class TheaterShowTimeQueries
{
	public const string CreateRecordSql = @"
            DECLARE @output TABLE (""Id"" BIGINT);
            INSERT INTO ""tblTheaterShowTime"" (
                ""sht_TheaterId"",
                ""sht_MovieId"",
                ""sht_StartDateTimeUtc"",
                ""sht_EndDateTimeUtc"",
                ""sht_TicketPriceUsd""
            ) 
            OUTPUT 
                INSERTED.""sht_Id""
                INTO @output
            VALUES (
                @TheaterId,
                @MovieId,
                @StartDateTimeUtc,
                @EndDateTimeUtc,
                @TicketPriceUsd
            );

            SELECT ""Id"" FROM @output;";

	public const string UpdateRecordSql = @"
            UPDATE ""tblTheaterShowTime"" SET
                ""sht_TheaterId""                = @TheaterId,
                ""sht_MovieId""                  = @MovieId,
                ""sht_StartDateTimeUtc""         = @StartDateTimeUtc,
                ""sht_EndDateTimeUtc""           = @EndDateTimeUtc,
                ""sht_TicketPriceUsd""           = @TicketPriceUsd
            WHERE
                ""tht_Id"" = @Id;";

	public const string GetRecordsSqlTemplate = @"
            SELECT
                TBL.""sht_Id""                      AS ""Id"",
                TBL.""sht_TheaterId""               AS ""TheaterId"",
                TBL.""sht_MovieId""                 AS ""MovieId"",
                TBL.""sht_StartDateTimeUtc""        AS ""StartDateTimeUtc"",
                TBL.""sht_EndDateTimeUtc""          AS ""EndDateTimeUtc"",
                TBL.""sht_TicketPriceUsd""          AS ""TicketPriceUsd""
            FROM ""tblTheaterShowTime"" TBL
            /**where**/";
    
    public const string DeleteRecordsSqlTemplate = @"
            UPDATE ""tblTheaterShowTime"" SET
                ""___EntityState"" = 'D'
            WHERE
                ""___EntityState"" <> 'D' AND ""sht_Id"" = @Id;";
}