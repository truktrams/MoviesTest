using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.BusinessLayer.Translators;
using MoviesTest.Web.Api.DataLayer.Interfaces;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class TheaterSeatBusinessService: ITheaterSeatBusinessService
{
    private readonly ITheaterSeatDataService _svcTheaterSeat;

    public TheaterSeatBusinessService(ITheaterSeatDataService svcTheaterSeat)
    {
        _svcTheaterSeat = svcTheaterSeat;
    }

    #region 'BusinessRepository'

    public async Task<IEnumerable<TheaterSeatModel>> GetRecords()
    {
        return (await _svcTheaterSeat.GetRecords()).Select(TheaterSeatTranslator.ToBusinessModel);
    }

    public async Task<TheaterSeatModel> GetRecord(long id)
    {
        return TheaterSeatTranslator.ToBusinessModel(await _svcTheaterSeat.GetRecord(id));
    }

    public async Task<long> CreateRecord(TheaterSeatModel model)
    {
        model.Validate();
        return await _svcTheaterSeat.CreateRecord(TheaterSeatTranslator.ToProjection(model));
    }

    public Task UpdateRecord(TheaterSeatModel model)
    {
        model.Validate();
        return _svcTheaterSeat.UpdateRecord(TheaterSeatTranslator.ToProjection(model));
    }

    public Task DeleteRecord(long id)
    {
        return _svcTheaterSeat.DeleteRecord(id);
    }

    #endregion
    
}