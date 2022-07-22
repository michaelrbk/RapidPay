namespace RapidPay.Api.Contracts.Data;

public class PayDto
{
    public string Id { get; init; } = default!;

    public decimal Fee { get; init; } = default!;

    public decimal Amount { get; init; } = default!;
}