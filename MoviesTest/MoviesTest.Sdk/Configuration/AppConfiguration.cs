using System.Collections.Concurrent;
using MoviesTest.Sdk.Exceptions;

namespace MoviesTest.Sdk.Configuration;

public static class AppConfiguration
{
    public const string ServiceDefaultDbConnectionStringKey = "SERVICE_DEFAULT_DB_CONNECTION_STRING";
    private static readonly ConcurrentDictionary<string, string> Configuration;

    static AppConfiguration() => Configuration = new ConcurrentDictionary<string, string>();

    public static void AddOrUpdate(string key, string value) =>
        Configuration.AddOrUpdate(key, value, (k, ov) => value);

    public static string GetValue(string key) =>
        Configuration.TryGetValue(key, out var value) ? value : throw new MoviesTestException($"Error during access to configuration property: '{key}'.");
}