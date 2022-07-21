namespace RapidPay.Api.Contracts.Responses;

public class CardResponse
{
    public Guid Id { get; init; }

    public string CardNumber { get; init; } = default!;
}