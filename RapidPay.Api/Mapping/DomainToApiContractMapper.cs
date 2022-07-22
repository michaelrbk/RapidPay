using RapidPay.Api.Contracts.Requests;
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
            CardNumber = card.CardNumber.Value,
            Balance = card.Balance.Value
        };
    }

    public static PayResponse ToPayResponse(this Card card, PayRequest req)
    {
        return new PayResponse
        {
            CardId = card.Id.Value,
            CardNumber = card.CardNumber.Value,
            Balance = card.Balance.Value,
            Amount = req.Amount
        };
    }
}