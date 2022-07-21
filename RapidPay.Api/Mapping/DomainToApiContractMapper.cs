using RapidPay.Api.Contracts.Responses;
using RapidPay.Api.Domain;

namespace RapidPay.Api.Mapping;

public static class DomainToApiContractMapper
{
    public static CardResponse ToCardResponse(this Card card)
    {
        return new CardResponse
        {
            Id = card.Id.Value,
            CardNumber = card.CardNumber.Value
        };
    }
}