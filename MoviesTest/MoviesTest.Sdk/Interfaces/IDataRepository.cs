namespace MoviesTest.Sdk.Interfaces;

public interface IDataRepository<TProjection, TPrimaryKey>
{
    Task<IEnumerable<TProjection>> GetRecords();
    Task<TProjection> GetRecord(TPrimaryKey key);
    Task<TPrimaryKey> CreateRecord(TProjection model);
    Task UpdateRecord(TProjection model);
    Task DeleteRecord(TPrimaryKey key);
}