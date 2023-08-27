using FluentAssertions;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class UserModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string IsActive { get; set; }

    public void Validate()
    {
        this.FirstName.Should().NotBeNullOrWhiteSpace("FirstName should be specified.");
        this.LastName.Should().NotBeNullOrWhiteSpace("LastName should be specified.");
        this.Login.Should().NotBeNullOrWhiteSpace("Login should be specified.");
        this.Email.Should().NotBeNullOrWhiteSpace("Email should be specified.");
        this.Phone.Should().NotBeNullOrWhiteSpace("Phone should be specified.");
    }
}