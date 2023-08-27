namespace MoviesTest.Web.Api.DataLayer.SqlQueries;

internal static class TheaterSeatQueries
{
	public const string CreateRecordSql = @"
            DECLARE @output TABLE (""Id"" BIGINT);
            INSERT INTO ""tblTheaterSeat"" (
                ""ths_TheaterId"",
                ""ths_Title"",
                ""ths_SeatPrice""
            )
            OUTPUT 
                INSERTED.""ths_Id""
                INTO @output
            VALUES (
                @TheaterId,
                @Title,
                @SeatPrice
            );

            SELECT ""Id"" FROM @output;";

	public const string UpdateRecordSql = @"
            UPDATE ""tblTheaterSeat"" SET
                ""ths_TheaterId""                   = @TheaterId,
                ""ths_Title""                       = @Title,
                ""ths_SeatPrice""                   = @SeatPrice
            WHERE
                ""ths_Id"" = @Id;";

	public const string GetRecordsSqlTemplate = @"
            SELECT 
                TBL.""ths_Id""                       AS ""Id"",
                TBL.""ths_TheaterId""                AS ""TheaterId"",
                TBL.""ths_Title""                    AS ""Title"",
                TBL.""ths_SeatPrice""                AS ""SeatPrice""
            FROM ""tblTheaterSeat"" TBL
            /**where**/";
    
    public const string DeleteRecordsSqlTemplate = @"
            UPDATE ""tblTheaterSeat"" SET
                ""___EntityState"" = 'D'
            WHERE
                ""___EntityState"" <> 'D' AND ""ths_Id"" = @Id;";
}