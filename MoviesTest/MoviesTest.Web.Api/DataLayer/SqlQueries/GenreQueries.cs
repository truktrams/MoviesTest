namespace MoviesTest.Web.Api.DataLayer.SqlQueries;

internal static class GenreQueries
{
    public const string CreateRecordSql = @"
            DECLARE @output TABLE (""Code"" nvarchar(MAX));
        
            INSERT INTO ""tblGenre"" (
                ""gnr_Code"",
                ""gnr_Title""
            ) 
            OUTPUT 
                INSERTED.""gnr_Code""
                INTO @output
            VALUES (
                @Code,
                @Title
            );

            SELECT ""Code"" FROM @output;";

	public const string UpdateRecordSql = @"
            UPDATE ""tblGenre"" SET
                ""gnr_Code""             = @Code,
                ""gnr_Title""            = @Title
            WHERE
                ""gnr_Code"" = @Code;";

	public const string GetRecordsSqlTemplate = @"
            SELECT 
                TBL.""gnr_Code""           AS ""Code"",
                TBL.""gnr_Title""          AS ""Title""
            FROM ""tblGenre"" TBL
            /**where**/";

	public const string DeleteRecordsSqlTemplate = @"
            UPDATE ""tblGenre"" SET
                ""___EntityState"" = 'D'
            WHERE
                ""___EntityState"" <> 'D' AND ""gnr_Code"" = @Code;";
}