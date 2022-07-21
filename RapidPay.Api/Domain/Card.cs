using RapidPay.Api.Domain.ValueObjects;

namespace RapidPay.Api.Domain;

public class Card
{
    public Id Id { get; init; } = Id.From(Guid.NewGuid());

    public CardNumber CardNumber { get; init; } = default!;

    public PositiveAmount Balance { get; init; } = PositiveAmount.From(decimal.Zero);
}