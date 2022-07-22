namespace RapidPay.Api.Contracts.Requests;

public class GetCardRequest
{
    public Guid CardId { get; init; } = default!;
}