using RapidPay.Api.Contracts.Data;
using RapidPay.Api.Domain;
using RapidPay.Api.Domain.ValueObjects;

namespace RapidPay.Api.Mapping;

public static class DtoToDomainMapper
{
    public static Card ToCard(this CardDto cardDto)
    {
        return new Card
        {
            Id = Id.From(Guid.Parse(cardDto.Id)),
            CardNumber = CardNumber.From(cardDto.CardNumber),
            Balance = PositiveAmount.From(cardDto.Balance)
        };
    }
}