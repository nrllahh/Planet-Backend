using System.Data.Common;

namespace Planet.Application.Services.SqlConnection
{
    public interface ISqlConnectionFactory
    {
        DbConnection GetConnection();
    }
}
