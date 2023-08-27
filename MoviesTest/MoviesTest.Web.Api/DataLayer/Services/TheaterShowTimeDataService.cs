using Dapper;
using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;
using MoviesTest.Web.Api.DataLayer.SqlQueries;

namespace MoviesTest.Web.Api.DataLayer.Services;

public class TheaterShowTimeDataService : ITheaterShowTimeDataService
{
    private readonly IDbConnectionManager _dbConnectionManager;

    public TheaterShowTimeDataService(IDbConnectionManager dbConnectionManager)
    {
        _dbConnectionManager = dbConnectionManager;
    }

    #region 'DataRepository'

    public async Task<IEnumerable<TheaterShowTimeProjection>> GetRecords()
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .AddTemplate(TheaterShowTimeQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<TheaterShowTimeProjection>(query.RawSql, new { EntityState = "D" });
    }

    public async Task<TheaterShowTimeProjection> GetRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("sht_Id = @Id")
            .AddTemplate(TheaterShowTimeQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<TheaterShowTimeProjection>(query.RawSql, new { EntityState = "D", Id = id });
    }

    public async Task<long> CreateRecord(TheaterShowTimeProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var id = await connection.QuerySingleAsync<long>(TheaterShowTimeQueries.CreateRecordSql, projection);
        return id;
    }

    public async Task UpdateRecord(TheaterShowTimeProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(TheaterShowTimeQueries.UpdateRecordSql, projection);
    }

    public async Task DeleteRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(TheaterShowTimeQueries.DeleteRecordsSqlTemplate, new { Id = id });
    }
    
    #endregion
}