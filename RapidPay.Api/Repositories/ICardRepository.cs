using RapidPay.Api.Contracts.Data;

namespace RapidPay.Api.Repositories;

public interface ICardRepository
{
    Task<bool> CreateAsync(CardDto card);

    Task<CardDto?> GetAsync(Guid id);

    Task<bool> UpdateAsync(CardDto cardDto);
}