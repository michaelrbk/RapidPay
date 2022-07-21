namespace RapidPay.Api.Contracts.Data;

public class CardDto
{
    public string Id { get; init; } = default!;

    public string CardNumber { get; init; } = default!;

    public decimal Balance { get; init; } = default!;
}