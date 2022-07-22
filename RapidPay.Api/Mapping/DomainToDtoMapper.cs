using RapidPay.Api.Contracts.Data;
using RapidPay.Api.Domain;
using RapidPay.Api.Domain.ValueObjects;

namespace RapidPay.Api.Mapping;

public static class DomainToDtoMapper
{
    public static CardDto ToCardDto(this Card card)
    {
        return new CardDto
        {
            Id = card.Id.Value.ToString(),
            CardNumber = card.CardNumber.Value,
            Balance = card.Balance.Value
        };
    }

    public static PayDto ToPayDto(this Card card, PositiveAmount amount, decimal ufeFee)
    {
        return new PayDto
        {
            Id = card.Id.Value.ToString(),
            Amount = amount.Value,
            Fee = ufeFee
        };
    }
}