using Dapper;
using RapidPay.Api.Contracts.Data;
using RapidPay.Api.Database;

namespace RapidPay.Api.Repositories;

public class CardRepository : ICardRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CardRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(CardDto card)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO cards (Id, card_number, balance) 
            VALUES (@Id, @CardNumber, @Balance)",
            card);
        return result > 0;
    }

    public async Task<CardDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<CardDto>(
            "SELECT * FROM cards WHERE Id = @Id LIMIT 1",
            new {Id = id.ToString()});
    }

    public async Task<bool> UpdateAsync(CardDto card)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE cards SET Balance = @Balance WHERE Id = @Id",
            card);
        return result > 0;
    }
}