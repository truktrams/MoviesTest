using System.Data.SqlClient;
using MoviesTest.Sdk.Configuration;
using MoviesTest.Sdk.Interfaces;

namespace MoviesTest.Sdk.Services;

public class DbConnectionManager : IDbConnectionManager
{
    public SqlConnection GetDbConnection() => new SqlConnection(AppConfiguration.GetValue(AppConfiguration.ServiceDefaultDbConnectionStringKey));
}