using RapidPay.Api.Domain;
using RapidPay.Api.Domain.ValueObjects;

namespace RapidPay.Api.Services;

public interface ICardService
{
    Task<bool> CreateAsync(Card card);

    Task<Card?> GetAsync(Guid id);

    Task<bool> PayAsync(Card card, PositiveAmount amount);
}