using System.Data.SqlClient;

namespace MoviesTest.Sdk.Interfaces;

public interface IDbConnectionManager
{
    SqlConnection GetDbConnection();
}