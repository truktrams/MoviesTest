using FluentAssertions;

namespace MoviesTest.Web.Api.BusinessLayer.Models;

public class MovieModel
{
    public long Id { get; set; }
    public string GenreCode { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public float Rating { get; set; }
    public string Description { get; set; }
    public long DurationTicks { get; set; }

    public void Validate()
    {
        this.Title.Should().NotBeNullOrWhiteSpace("Title can not be null.");
        this.Year.Should().BeInRange(1600, DateTime.UtcNow.Year, "Year should be in valid range (1600 ~ Current).");
        this.Rating.Should().BeInRange(0, 10, "Rating should be in valid range (0 ~ 10).");
        this.Rating.Should().BeGreaterThan(0, "DurationTicks should be greater than 0.");
    }
}