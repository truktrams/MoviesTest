using Dapper;
using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;
using MoviesTest.Web.Api.DataLayer.SqlQueries;

namespace MoviesTest.Web.Api.DataLayer.Services;

public class MovieDataService : IMovieDataService
{
    private readonly IDbConnectionManager _dbConnectionManager;

    public MovieDataService(IDbConnectionManager dbConnectionManager)
    {
        _dbConnectionManager = dbConnectionManager;
    }

    #region 'DataRepository'

    public async Task<IEnumerable<MovieProjection>> GetRecords()
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .AddTemplate(MovieQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<MovieProjection>(query.RawSql, new { EntityState = "D" });
    }

    public async Task<MovieProjection> GetRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("mov_Id = @Id")
            .AddTemplate(MovieQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<MovieProjection>(query.RawSql, new { EntityState = "D", Id = id });
    }

    public async Task<long> CreateRecord(MovieProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var id = await connection.QuerySingleAsync<long>(MovieQueries.CreateRecordSql, projection);
        return id;
    }

    public async Task UpdateRecord(MovieProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(MovieQueries.UpdateRecordSql, projection);
    }

    public async Task DeleteRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(MovieQueries.DeleteRecordsSqlTemplate, new { Id = id });
    }
    
    #endregion
    
}