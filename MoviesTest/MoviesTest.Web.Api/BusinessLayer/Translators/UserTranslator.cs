using MoviesTest.Web.Api.BusinessLayer.Models;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.BusinessLayer.Translators;

public class UserTranslator
{
    public static UserModel ToBusinessModel(UserProjection mdl) => new UserModel()
    {
        Id = mdl.Id,
        FirstName = mdl.FirstName,
        LastName = mdl.LastName,
        Login = mdl.Login,
        Email = mdl.Email,
        Phone = mdl.Phone,
        IsActive = mdl.IsActive
    };

    public static UserProjection ToProjection(UserModel mdl) => new UserProjection()
    {
        Id = mdl.Id,
        FirstName = mdl.FirstName,
        LastName = mdl.LastName,
        Login = mdl.Login,
        PasswordHash = mdl.Password + "-HASHED",
        Email = mdl.Email,
        Phone = mdl.Phone,
        IsActive = mdl.IsActive
    };
}