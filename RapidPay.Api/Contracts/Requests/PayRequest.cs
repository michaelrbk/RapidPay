namespace RapidPay.Api.Contracts.Requests;

public class PayRequest
{
    public Guid CardId { get; init; } = default!;

    public decimal Amount { get; init; } = default!;
}