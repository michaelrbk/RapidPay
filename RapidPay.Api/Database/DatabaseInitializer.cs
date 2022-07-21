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
            CREATE TABLE IF NOT EXISTS cards(
                          id         CHAR(36) PRIMARY KEY,
                          card_number CHAR(15) NOT NULL,
                          balance DECIMAL NOT NULL
             )
        ");


        /*
        CREATE TABLE IF NOT EXISTS payments(
            id     char(36) PRIMARY KEY,
            card_id char(15) NOT NULL,
            value decimal NOT NULL,
            FOREIGN KEY(card_id) REFERENCES cards(id)
            );
        CREATE TABLE IF NOT EXISTS fees (
            id  char(36) PRIMARY KEY,
            fee decimal NOT NULL
            );*/
    }
}