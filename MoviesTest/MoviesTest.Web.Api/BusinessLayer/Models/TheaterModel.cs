using FluentAssertions;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class TheaterModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    
    public void Validate()
    {
        this.Title.Should().NotBeNullOrWhiteSpace("Title can not be null.");
    }
}