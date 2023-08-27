using MoviesTest.Sdk.Configuration;

namespace MoviesTest.Web.Api.Infrastructure;

public static class ApplicationInitializer
{
    public static void InitializeDefaultSettings()
    {
        AppConfiguration.AddOrUpdate(AppConfiguration.ServiceDefaultDbConnectionStringKey, "Server=localhost;User Id=sa;Database=MoviesTestDb;Password=admin123;");
    }
}