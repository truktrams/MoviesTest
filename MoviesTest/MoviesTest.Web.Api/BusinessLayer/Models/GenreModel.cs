using FluentAssertions;
using Microsoft.AspNetCore.Identity;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class GenreModel
{
    public string Code { get; set; }
    public string Title { get; set; }

    public void Validate()
    {
        this.Code.Should().NotBeNullOrWhiteSpace("Code can not be null.");
        this.Title.Should().NotBeNullOrWhiteSpace("Title can not be null.");
    }
}