using Dapper;
using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;
using MoviesTest.Web.Api.DataLayer.SqlQueries;

namespace MoviesTest.Web.Api.DataLayer.Services;

public class UserDataService : IUserDataService
{
    private readonly IDbConnectionManager _dbConnectionManager;

    public UserDataService(IDbConnectionManager dbConnectionManager)
    {
        _dbConnectionManager = dbConnectionManager;
    }

    #region 'DataRepository'

    public async Task<IEnumerable<UserProjection>> GetRecords()
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .AddTemplate(UserQueries.GetRecordsSqlTemplate);
        return await connection.QueryAsync<UserProjection>(query.RawSql, new { EntityState = "D" });
    }

    public async Task<UserProjection> GetRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var builder = new SqlBuilder();
        var query = builder
            .Where("___EntityState <> @EntityState")
            .Where("usr_Id = @Id")
            .AddTemplate(UserQueries.GetRecordsSqlTemplate);
        return await connection.QuerySingleOrDefaultAsync<UserProjection>(query.RawSql, new { EntityState = "D", Id = id });
    }

    public async Task<long> CreateRecord(UserProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        var id = await connection.QuerySingleAsync<long>(UserQueries.CreateRecordSql, projection);
        return id;
    }

    public async Task UpdateRecord(UserProjection projection)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(UserQueries.UpdateRecordSql, projection);
    }

    public async Task DeleteRecord(long id)
    {
        await using var connection = _dbConnectionManager.GetDbConnection();
        await connection.QueryAsync(UserQueries.DeleteRecordsSqlTemplate, new { Id = id });
    }
    
    #endregion
}