using System.Collections.Immutable;

namespace MoviesTest.Web.Api.DataLayer.Projections;

public class UserProjection
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string IsActive { get; set; }
}