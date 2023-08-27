namespace MoviesTest.Web.Api.DataLayer.SqlQueries;

internal static class MovieQueries
{
	public const string CreateRecordSql = @"
            DECLARE @output TABLE (""Id"" BIGINT);
            INSERT INTO ""tblMovie"" (
                ""mov_Title"",
                ""mov_GenreCode"",
                ""mov_Year"",
                ""mov_Rating"",
                ""mov_Description"",
                ""mov_DurationTicks""
            )
            OUTPUT 
                INSERTED.""mov_Id""
                INTO @output
             VALUES (
                @Title,
                @GenreCode,
                @Year,
                @Rating,
                @Description,
                @DurationTicks
            );

            SELECT ""Id"" FROM @output;";

	public const string UpdateRecordSql = @"
            UPDATE ""tblMovie"" SET
                ""mov_Title""                 = @Title,
                ""mov_GenreCode""             = @GenreCode,
                ""mov_Year""                  = @Year,
                ""mov_Rating""                = @Rating,
                ""mov_Description""           = @Description,
                ""mov_DurationTicks""          = @DurationTicks
            WHERE
                ""mov_Id"" = @Id;";

	public const string GetRecordsSqlTemplate = @"
            SELECT 
                TBL.""mov_Id""                    AS ""Id"",
                TBL.""mov_Title""                 AS ""Title"",
                TBL.""mov_GenreCode""             AS ""GenreCode"",
                TBL.""mov_Year""                  AS ""Year"",
                TBL.""mov_Rating""                AS ""Rating"",
                TBL.""mov_Description""           AS ""Description"",
                TBL.""mov_DurationTicks""          AS ""DurationTicks""
            FROM ""tblMovie"" TBL
            /**where**/";

    public const string DeleteRecordsSqlTemplate = @"
            UPDATE ""tblMovie"" SET
                ""___EntityState"" = 'D'
            WHERE
                ""___EntityState"" <> 'D' AND ""mov_Id"" = @Id;";
}