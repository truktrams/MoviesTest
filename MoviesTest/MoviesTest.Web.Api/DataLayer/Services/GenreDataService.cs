using Dapper;
using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;
using MoviesTest.Web.Api.DataLayer.SqlQueries;

namespace MoviesTest.Web.Api.DataLayer.Services;

public class GenreDataService : IGenreDataService
{
    private readonly IDbConnectionManager _dbConnectionManager;

    public GenreDataService(IDbConnectionManager dbConnectionManager)
    {
        _dbConnectionManager = dbConnectionManager;
    }

    #region 'DataRepository'

    public async Task<IEnumerable<GenreProjection>> GetRecords()
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .AddTemplate(GenreQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<GenreProjection>(query.RawSql, new { EntityState = "D" });
    }

    public async Task<GenreProjection> GetRecord(string code)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("gnr_Code = @Code")
            .AddTemplate(GenreQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<GenreProjection>(query.RawSql, new { EntityState = "D",Code = code });
    }

    public async Task<string> CreateRecord(GenreProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var code = await connection.QuerySingleAsync<string>(GenreQueries.CreateRecordSql, projection);
        return code;
    }

    public async Task UpdateRecord(GenreProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(GenreQueries.UpdateRecordSql, projection);
    }

    public async Task DeleteRecord(string code)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(GenreQueries.DeleteRecordsSqlTemplate, new { Code = code });
    }
    
    #endregion
    
}