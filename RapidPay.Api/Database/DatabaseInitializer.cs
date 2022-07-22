using Dapper;

namespace RapidPay.Api.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"
            CREATE TABLE IF NOT EXISTS Cards(
                          Id         CHAR(36) PRIMARY KEY,
                          CardNumber CHAR(15) NOT NULL,
                          Balance DECIMAL NOT NULL
             )
        ");
    }
}