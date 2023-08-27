using Dapper;
using MoviesTest.Sdk.Constants;
using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;
using MoviesTest.Web.Api.DataLayer.SqlQueries;

namespace MoviesTest.Web.Api.DataLayer.Services;

public class TheaterSeatReservationDataService : ITheaterSeatReservationDataService
{
    private readonly IDbConnectionManager _dbConnectionManager;

    public TheaterSeatReservationDataService(IDbConnectionManager dbConnectionManager)
    {
        _dbConnectionManager = dbConnectionManager;
    }

    #region 'DataRepository'

    public async Task<IEnumerable<TheaterSeatReservationProjection>> GetRecords()
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .AddTemplate(TheaterSeatReservationQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<TheaterSeatReservationProjection>(query.RawSql, new { EntityState = "D" });
    }

    public async Task<TheaterSeatReservationProjection> GetRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("tsr_Id = @Id")
            .AddTemplate(TheaterSeatReservationQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<TheaterSeatReservationProjection>(query.RawSql, new { EntityState = "D", Id = id });
    }

    public async Task<long> CreateRecord(TheaterSeatReservationProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var id = await connection.QuerySingleAsync<long>(TheaterSeatReservationQueries.CreateRecordSql, projection);
        return id;
    }

    public async Task UpdateRecord(TheaterSeatReservationProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(TheaterSeatReservationQueries.UpdateRecordSql, projection);
    }

    public async Task DeleteRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(TheaterSeatReservationQueries.DeleteRecordsSqlTemplate, new { Id = id });
    }
    
    #endregion

    public async Task<IEnumerable<TheaterSeatReservationProjection>> GetRecordsForReservation(long reservationId)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("tsr_ReservationId = @ReservationId")
            .AddTemplate(TheaterSeatReservationQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<TheaterSeatReservationProjection>(query.RawSql, new { EntityState = "D", ReservationId = reservationId });
    }

    public async Task<bool> CheckTheaterSeatsReservationAvailability(long showTimeId, long[] seatIds)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where(@"THEATER_SEAT_RESERVATION.""___EntityState"" <> @EntityState")
            .Where(@"RESERVATION.""rsv_ReservationStateCode"" <> @ReservationStateCode")
            .Where(@"THEATER_SEAT_RESERVATION.""tsr_TheaterShowTimeId"" = @ShowTimeId")
            .Where(@"THEATER_SEAT_RESERVATION.""tsr_TheaterSeatId"" IN @SeatIds")
            .AddTemplate(TheaterSeatReservationQueries.CheckTheaterSeatsReservationAvailability);
        return await connection.QuerySingleOrDefaultAsync<bool>(query.RawSql, new
        {
            EntityState = "D",
            ReservationStateCode = ReservationStates.Expired,
            ShowTimeId = showTimeId,
            SeatIds = seatIds
        });
    }
}