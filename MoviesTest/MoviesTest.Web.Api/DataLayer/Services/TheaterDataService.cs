using Dapper;
using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;
using MoviesTest.Web.Api.DataLayer.SqlQueries;

namespace MoviesTest.Web.Api.DataLayer.Services;

public class TheaterDataService: ITheaterDataService
{
    private readonly IDbConnectionManager _dbConnectionManager;

    public TheaterDataService(IDbConnectionManager dbConnectionManager)
    {
        _dbConnectionManager = dbConnectionManager;
    }

    #region 'DataRepository'

    public async Task<IEnumerable<TheaterProjection>> GetRecords()
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .AddTemplate(TheaterQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<TheaterProjection>(query.RawSql, new { EntityState = "D" });
    }

    public async Task<TheaterProjection> GetRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("tht_Id = @Id")
            .AddTemplate(TheaterQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<TheaterProjection>(query.RawSql, new { EntityState = "D", Id = id });
    }

    public async Task<long> CreateRecord(TheaterProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var id = await connection.QuerySingleAsync<long>(TheaterQueries.CreateRecordSql, projection);
        return id;
    }

    public async Task UpdateRecord(TheaterProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(TheaterQueries.UpdateRecordSql, projection);
    }

    public async Task DeleteRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(TheaterQueries.DeleteRecordsSqlTemplate, new { Id = id });
    }
    
    #endregion
}