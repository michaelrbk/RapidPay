namespace RapidPay.Api.Contracts.Responses;

public class PayResponse
{
    public Guid CardId { get; init; }

    public string CardNumber { get; init; } = default!;

    public decimal Amount { get; init; } = default!;

    public decimal Balance { get; init; } = default!;
}