namespace MoviesTest.Sdk.Interfaces;

public interface IBusinessRepositoryAggregated<TBusinessEntity, TPrimaryKey>
{
    Task<IEnumerable<TBusinessEntity>> GetRecordsAggregated();
    Task<TBusinessEntity> GetRecordAggregated(TPrimaryKey key);
    Task<TPrimaryKey> CreateRecordAggregated(TBusinessEntity model);
    Task UpdateRecordAggregated(TBusinessEntity model);
    Task DeleteRecordAggregated(TPrimaryKey key);
}