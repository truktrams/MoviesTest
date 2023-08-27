using MoviesTest.Web.Api.BusinessLayer.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.BusinessLayer.Translators;
using MoviesTest.Web.Api.DataLayer.Interfaces;

namespace MoviesTest.Web.Api.BusinessLayer.Services;

public class UserBusinessService: IUserBusinessService
{
    private readonly IUserDataService _svcUser;

    public UserBusinessService(IUserDataService svcUser)
    {
        _svcUser = svcUser;
    }

    #region 'BusinessRepository'

    public async Task<IEnumerable<UserModel>> GetRecords()
    {
        return (await _svcUser.GetRecords()).Select(UserTranslator.ToBusinessModel);
    }

    public async Task<UserModel> GetRecord(long id)
    {
        return UserTranslator.ToBusinessModel(await _svcUser.GetRecord(id));
    }

    public async Task<long> CreateRecord(UserModel model)
    {
        model.Validate();
        return await _svcUser.CreateRecord(UserTranslator.ToProjection(model));
    }

    public Task UpdateRecord(UserModel model)
    {
        model.Validate();
        return _svcUser.UpdateRecord(UserTranslator.ToProjection(model));
    }

    public Task DeleteRecord(long id)
    {
        return _svcUser.DeleteRecord(id);
    }

    #endregion
}