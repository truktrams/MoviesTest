using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.BusinessLayer.Translators;
using MoviesTest.Web.Api.DataLayer.Interfaces;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class GenreBusinessService: IGenreBusinessService
{
    private readonly IGenreDataService _svcGenre;

    public GenreBusinessService(IGenreDataService svcGenre)
    {
        _svcGenre = svcGenre;
    }

    #region 'BusinessRepository'

    public async Task<IEnumerable<GenreModel>> GetRecords()
    {
        return (await _svcGenre.GetRecords()).Select(GenreTranslator.ToBusinessModel);
    }

    public async Task<GenreModel> GetRecord(string code)
    {
        return GenreTranslator.ToBusinessModel(await _svcGenre.GetRecord(code));
    }

    public async Task<string> CreateRecord(GenreModel model)
    {
        model.Validate();
        return await _svcGenre.CreateRecord(GenreTranslator.ToProjection(model));
    }

    public Task UpdateRecord(GenreModel model)
    {
        model.Validate();
        return _svcGenre.UpdateRecord(GenreTranslator.ToProjection(model));
    }

    public Task DeleteRecord(string code)
    {
        return _svcGenre.DeleteRecord(code);
    }

    #endregion
    
}