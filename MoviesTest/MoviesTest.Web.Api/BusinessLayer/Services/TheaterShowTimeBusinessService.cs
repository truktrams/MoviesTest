using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.BusinessLayer.Translators;
using MoviesTest.Web.Api.DataLayer.Interfaces;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class TheaterShowTimeBusinessService: ITheaterShowTimeBusinessService
{
    private readonly ITheaterShowTimeDataService _svcTheaterShowTime;

    public TheaterShowTimeBusinessService(ITheaterShowTimeDataService svcTheaterShowTime)
    {
        _svcTheaterShowTime = svcTheaterShowTime;
    }

    #region 'BusinessRepository'

    public async Task<IEnumerable<TheaterShowTimeModel>> GetRecords()
    {
        return (await _svcTheaterShowTime.GetRecords()).Select(TheaterShowTimeTranslator.ToBusinessModel);
    }

    public async Task<TheaterShowTimeModel> GetRecord(long id)
    {
        return TheaterShowTimeTranslator.ToBusinessModel(await _svcTheaterShowTime.GetRecord(id));
    }

    public async Task<long> CreateRecord(TheaterShowTimeModel model)
    {
        model.Validate();
        return await _svcTheaterShowTime.CreateRecord(TheaterShowTimeTranslator.ToProjection(model));
    }

    public Task UpdateRecord(TheaterShowTimeModel model)
    {
        model.Validate();
        return _svcTheaterShowTime.UpdateRecord(TheaterShowTimeTranslator.ToProjection(model));
    }

    public Task DeleteRecord(long id)
    {
        return _svcTheaterShowTime.DeleteRecord(id);
    }

    #endregion
    
}