namespace MoviesTest.Web.Api.DataLayer.SqlQueries;

internal static class ReservationQueries
{
    public const string CreateRecordSql = @"
            DECLARE @output TABLE (""Id"" BIGINT);
            INSERT INTO ""tblReservation"" (
                ""rsv_ReservationStateCode"",
                ""rsv_UserId"",
                ""rsv_TheaterId"",
                ""rsv_TheaterShowTimeId"",
                ""rsv_ReservedAt"",
                ""rsv_ApprovalKey""
            ) 
            OUTPUT 
                INSERTED.""rsv_Id""
                INTO @output
            VALUES (
                @ReservationStateCode,
                @UserId,
                @TheaterId,
                @TheaterShowTimeId,
                @ReservedAt,
                @ApprovalKey
            );

            SELECT ""Id"" FROM @output;";

    public const string UpdateRecordSql = @"
            UPDATE ""tblReservation"" SET
                ""rsv_ReservationStateCode""        = @ReservationStateCode,
                ""rsv_UserId""                      = @UserId,
                ""rsv_TheaterId""                   = @TheaterId,
                ""rsv_TheaterShowTimeId""           = @TheaterShowTimeId,
                ""rsv_ReservedAt""                  = @ReservedAt,
                ""rsv_ApprovalKey""                 = @ApprovalKey
            WHERE
                ""rsv_Id"" = @Id;";

    public const string GetRecordsSqlTemplate = @"
            SELECT 
                TBL.""rsv_Id""                          AS ""Id"",
                TBL.""rsv_ReservationStateCode""        AS ""ReservationStateCode"",
                TBL.""rsv_UserId""                      AS ""UserId"",
                TBL.""rsv_TheaterId""                   AS ""TheaterId"",
                TBL.""rsv_TheaterShowTimeId""           AS ""TheaterShowTimeId"",
                TBL.""rsv_ReservedAt""                  AS ""ReservedAt"",
                TBL.""rsv_ApprovalKey""                 AS ""ApprovalKey""
            FROM ""tblReservation"" TBL
            /**where**/";

    public const string DeleteRecordsSqlTemplate = @"
            UPDATE ""tblReservation"" SET
                ""___EntityState"" = 'D'
            WHERE
                ""___EntityState"" <> 'D' AND ""rsv_Id"" = @Id;";
}