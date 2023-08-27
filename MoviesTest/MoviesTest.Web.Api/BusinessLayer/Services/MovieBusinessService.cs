using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.BusinessLayer.Translators;
using MoviesTest.Web.Api.DataLayer.Interfaces;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class MovieBusinessService: IMovieBusinessService
{
    private readonly IMovieDataService _svcMovie;

    public MovieBusinessService(IMovieDataService svcMovie)
    {
        _svcMovie = svcMovie;
    }

    #region 'BusinessRepository'

    public async Task<IEnumerable<MovieModel>> GetRecords()
    {
        return (await _svcMovie.GetRecords()).Select(MovieTranslator.ToBusinessModel);
    }

    public async Task<MovieModel> GetRecord(long id)
    {
        return MovieTranslator.ToBusinessModel(await _svcMovie.GetRecord(id));
    }

    public async Task<long> CreateRecord(MovieModel model)
    {
        model.Validate();
        return await _svcMovie.CreateRecord(MovieTranslator.ToProjection(model));
    }

    public Task UpdateRecord(MovieModel model)
    {
        model.Validate();
        return _svcMovie.UpdateRecord(MovieTranslator.ToProjection(model));
    }

    public Task DeleteRecord(long id)
    {
        return _svcMovie.DeleteRecord(id);
    }

    #endregion
    
}