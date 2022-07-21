using RapidPay.Api.Contracts.Data;
using RapidPay.Api.Domain;

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
}