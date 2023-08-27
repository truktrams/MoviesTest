namespace MoviesTest.Web.Api.DataLayer.SqlQueries;

internal static class TheaterSeatReservationQueries
{
	public const string CreateRecordSql = @"
            DECLARE @output TABLE (""Id"" BIGINT);
            INSERT INTO ""tblTheaterSeatReservation"" (
                ""tsr_TheaterSeatId"",
                ""tsr_ReservationId"",
                ""tsr_TheaterShowTimeId""
            ) 
            OUTPUT 
                INSERTED.""tsr_Id""
                INTO @output
            VALUES (
                @TheaterSeatId,
                @ReservationId,
                @TheaterShowTimeId
            );

            SELECT ""Id"" FROM @output;";

	public const string UpdateRecordSql = @"
            UPDATE ""tblTheaterSeatReservation"" SET
                ""tsr_TheaterSeatId""               = @TheaterSeatId,
                ""tsr_ReservationId""               = @ReservationId,
                ""tsr_TheaterShowTimeId""           = @TheaterShowTimeId
            WHERE
                ""ths_Id"" = @Id;";

	public const string GetRecordsSqlTemplate = @"
            SELECT 
                TBL.""tsr_Id""                       AS ""Id"",
                TBL.""tsr_TheaterSeatId""            AS ""TheaterSeatId"",
                TBL.""tsr_ReservationId""            AS ""ReservationId"",
                TBL.""tsr_TheaterShowTimeId""        AS ""TheaterShowTimeId""
            FROM ""tblTheaterSeatReservation"" TBL
            /**where**/";
    
    public const string DeleteRecordsSqlTemplate = @"
            UPDATE ""tblTheaterSeatReservation"" SET
                ""___EntityState"" = 'D'
            WHERE
                ""___EntityState"" <> 'D' AND ""tsr_Id"" = @Id;";

    public const string CheckTheaterSeatsReservationAvailability = @"            
            SELECT CASE WHEN EXISTS (  
	            SELECT 
		            RESERVATION.""rsv_ReservationStateCode"" AS ""ReservationStateCode"",
                RESERVATION.""rsv_TheaterShowTimeId"" AS ""TheaterShowTimeId"",
                RESERVATION.""rsv_TheaterId"" AS TheaterId,
                    THEATER_SEAT_RESERVATION.""tsr_TheaterSeatId"" AS ""TheaterSeatId"",
                THEATER_SHOW_TIME.""sht_StartDateTimeUtc"" AS ""sht_StartDateTimeUtc"",
                THEATER_SHOW_TIME.""sht_EndDateTimeUtc"" AS ""sht_EndDateTimeUtc""
                FROM ""tblTheaterSeatReservation"" THEATER_SEAT_RESERVATION
                    INNER JOIN ""tblReservation"" RESERVATION 
                    ON RESERVATION.""rsv_Id"" = THEATER_SEAT_RESERVATION.""tsr_ReservationId"" 
                AND RESERVATION.""___EntityState"" <> 'D'
                INNER JOIN ""tblTheaterShowTime"" THEATER_SHOW_TIME 
                    ON RESERVATION.""rsv_TheaterShowTimeId"" = THEATER_SHOW_TIME.""sht_Id"" 
                AND THEATER_SHOW_TIME.""___EntityState"" <> 'D'
                    /**where**/
            )
            THEN 0
            ELSE 1
            END AS RESULT;";
}