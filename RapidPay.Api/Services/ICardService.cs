using RapidPay.Api.Domain;

namespace RapidPay.Api.Services;

public interface ICardService
{
    Task<bool> CreateAsync(Card card);

    Task<Card?> GetAsync(Guid id);

    Task<bool> UpdateAsync(Card card);
}