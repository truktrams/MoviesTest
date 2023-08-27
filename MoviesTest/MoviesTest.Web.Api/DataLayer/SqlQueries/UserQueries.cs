namespace MoviesTest.Web.Api.DataLayer.SqlQueries;

internal static class UserQueries
{
	public const string CreateRecordSql = @"
            DECLARE @output TABLE (""Id"" BIGINT);
            INSERT INTO ""tblUser"" (
                ""usr_FirstName"",
                ""usr_LastName"",
                ""usr_Login"",
                ""usr_PasswordHash"",
                ""usr_Email"",
                ""usr_Phone"",
                ""usr_IsActive""
            ) 
            OUTPUT 
                INSERTED.""usr_Id""
                INTO @output
            VALUES (
                @FirstName,
                @LastName,
                @Login,
                @PasswordHash,
                @Email,
                @Phone,
                @IsActive
            );

            SELECT ""Id"" FROM @output;";

	public const string UpdateRecordSql = @"
            UPDATE ""tblUser"" SET
                ""usr_FirstName""        = @FirstName,
                ""usr_LastName""         = @LastName,
                ""usr_Login""            = @Login,
                ""usr_PasswordHash""     = @PasswordHash,
                ""usr_Email""            = @Email,
                ""usr_Phone""            = @Phone,
                ""usr_IsActive""         = @IsActive
            WHERE
                ""usr_Id"" = @Id;";

	public const string GetRecordsSqlTemplate = @"
            SELECT
                TBL.""usr_Id""               AS  ""Id"",
                TBL.""usr_FirstName""        AS  ""FirstName"",
                TBL.""usr_LastName""         AS  ""LastName"",
                TBL.""usr_Login""            AS  ""Login"",
                TBL.""usr_PasswordHash""     AS  ""PasswordHash"",
                TBL.""usr_Email""            AS  ""Email"",
                TBL.""usr_Phone""            AS  ""Phone"",
                TBL.""usr_IsActive""         AS  ""IsActive""
            FROM ""tblUser"" TBL
            /**where**/";
    
    public const string DeleteRecordsSqlTemplate = @"
            UPDATE ""tblUser"" SET
                ""___EntityState"" = 'D'
            WHERE
                ""___EntityState"" <> 'D' AND ""usr_Id"" = @Id;";
}