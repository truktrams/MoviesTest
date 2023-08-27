using Dapper;
using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;
using MoviesTest.Web.Api.DataLayer.SqlQueries;

namespace MoviesTest.Web.Api.DataLayer.Services;

public class TheaterSeatDataService: ITheaterSeatDataService
{
    private readonly IDbConnectionManager _dbConnectionManager;

    public TheaterSeatDataService(IDbConnectionManager dbConnectionManager)
    {
        _dbConnectionManager = dbConnectionManager;
    }

    #region 'DataRepository'

    public async Task<IEnumerable<TheaterSeatProjection>> GetRecords()
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .AddTemplate(TheaterSeatQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<TheaterSeatProjection>(query.RawSql, new { EntityState = "D" });
    }

    public async Task<TheaterSeatProjection> GetRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("ths_Id = @Id")
            .AddTemplate(TheaterSeatQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<TheaterSeatProjection>(query.RawSql, new { EntityState = "D", Id = id });
    }

    public async Task<long> CreateRecord(TheaterSeatProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var id = await connection.QuerySingleAsync<long>(TheaterSeatQueries.CreateRecordSql, projection);
        return id;
    }

    public async Task UpdateRecord(TheaterSeatProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(TheaterSeatQueries.UpdateRecordSql, projection);
    }

    public async Task DeleteRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(TheaterSeatQueries.DeleteRecordsSqlTemplate, new { Id = id });
    }
    
    #endregion
}