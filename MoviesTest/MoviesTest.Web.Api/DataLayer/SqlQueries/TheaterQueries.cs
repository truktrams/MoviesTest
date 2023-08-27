namespace MoviesTest.Web.Api.DataLayer.SqlQueries;

internal static class TheaterQueries
{
	public const string CreateRecordSql = @"
            DECLARE @output TABLE (""Id"" BIGINT);
            INSERT INTO ""tblTheater"" (
                ""tht_Title""
            ) 
            OUTPUT 
                INSERTED.""tht_Id""
                INTO @output
            VALUES (
                @Title
            );

            SELECT ""Id"" FROM @output;";

	public const string UpdateRecordSql = @"
            UPDATE ""tblTheater"" SET
                ""tht_Title""                       = @Title
            WHERE
                ""tht_Id"" = @Id;";

	public const string GetRecordsSqlTemplate = @"
            SELECT 
                TBL.""tht_Id""                       AS ""Id"",
                TBL.""tht_Title""                    AS ""Title""
            FROM ""tblTheater"" TBL
            /**where**/";
    
    public const string DeleteRecordsSqlTemplate = @"
            UPDATE ""tblTheater"" SET
                ""___EntityState"" = 'D'
            WHERE
                ""___EntityState"" <> 'D' AND ""tht_Id"" = @Id;";
}