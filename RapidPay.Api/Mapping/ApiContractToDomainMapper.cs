using RapidPay.Api.Contracts.Requests;
using RapidPay.Api.Domain;
using RapidPay.Api.Domain.ValueObjects;

namespace RapidPay.Api.Mapping;

public static class ApiContractToDomainMapper
{
    public static Card ToCard(this CreateCardRequest request)
    {
        return new Card
        {
            Id = Id.From(Guid.NewGuid()),
            CardNumber = CardNumber.From(request.CardNumber)
        };
    }
}