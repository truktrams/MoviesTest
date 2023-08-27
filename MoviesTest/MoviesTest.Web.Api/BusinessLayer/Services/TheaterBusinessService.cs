using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.BusinessLayer.Translators;
using MoviesTest.Web.Api.DataLayer.Interfaces;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class TheaterBusinessService: ITheaterBusinessService
{
    private readonly ITheaterDataService _svcTheater;

    public TheaterBusinessService(ITheaterDataService svcTheater)
    {
        _svcTheater = svcTheater;
    }

    #region 'BusinessRepository'

    public async Task<IEnumerable<TheaterModel>> GetRecords()
    {
        return (await _svcTheater.GetRecords()).Select(TheaterTranslator.ToBusinessModel);
    }

    public async Task<TheaterModel> GetRecord(long id)
    {
        return TheaterTranslator.ToBusinessModel(await _svcTheater.GetRecord(id));
    }

    public async Task<long> CreateRecord(TheaterModel model)
    {
        model.Validate();
        return await _svcTheater.CreateRecord(TheaterTranslator.ToProjection(model));
    }

    public Task UpdateRecord(TheaterModel model)
    {
        model.Validate();
        return _svcTheater.UpdateRecord(TheaterTranslator.ToProjection(model));
    }

    public Task DeleteRecord(long id)
    {
        return _svcTheater.DeleteRecord(id);
    }

    #endregion
    
}