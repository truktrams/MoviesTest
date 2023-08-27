using Dapper;
using MoviesTest.Sdk.Constants;
using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;
using MoviesTest.Web.Api.DataLayer.SqlQueries;

namespace MoviesTest.Web.Api.DataLayer.Services;

public class ReservationDataService : IReservationDataService
{
    private readonly IDbConnectionManager _dbConnectionManager;

    public ReservationDataService(IDbConnectionManager dbConnectionManager)
    {
        _dbConnectionManager = dbConnectionManager;
    }

    #region 'DataRepository'

    public async Task<IEnumerable<ReservationProjection>> GetRecords()
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .AddTemplate(ReservationQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<ReservationProjection>(query.RawSql, new { EntityState = "D" });
    }

    public async Task<ReservationProjection> GetRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("rsv_Id = @Id")
            .AddTemplate(ReservationQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<ReservationProjection>(query.RawSql, new { EntityState = "D", Id = id });
    }

    public async Task<long> CreateRecord(ReservationProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var id = await connection.QuerySingleAsync<long>(ReservationQueries.CreateRecordSql, projection);
        return id;
    }

    public async Task UpdateRecord(ReservationProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(ReservationQueries.UpdateRecordSql, projection);
    }

    public async Task DeleteRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(ReservationQueries.DeleteRecordsSqlTemplate, new { Id = id });
    }
    
    #endregion

    public async Task<ReservationProjection> GetRecordByApprovalKey(Guid approvalKey)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("rsv_ApprovalKey = @ApprovalKey")
            .AddTemplate(ReservationQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<ReservationProjection>(query.RawSql, new { EntityState = "D", ApprovalKey = approvalKey });
    }

    public async Task<IEnumerable<ReservationProjection>> GetRecordsToExpire(DateTimeOffset expirationThreshold)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("rsv_ReservationStateCode = @ReservationStateCode")
            .Where("rsv_ReservedAt <= @ExpirationThreshold")
            .AddTemplate(ReservationQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<ReservationProjection>(query.RawSql, new
        {
            EntityState = "D",
            ExpirationThreshold = expirationThreshold,
            ReservationStateCode = ReservationStates.PendingApproval
        });
    }
}