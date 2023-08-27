namespace MoviesTest.Sdk.Interfaces;

public interface IBusinessRepository<TBusinessEntity, TPrimaryKey>
{
    Task<IEnumerable<TBusinessEntity>> GetRecords();
    Task<TBusinessEntity> GetRecord(TPrimaryKey key);
    Task<TPrimaryKey> CreateRecord(TBusinessEntity model);
    Task UpdateRecord(TBusinessEntity model);
    Task DeleteRecord(TPrimaryKey key);
}