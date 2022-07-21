namespace RapidPay.Api.Contracts.Requests;

public class CreateCardRequest
{
    public string CardNumber { get; init; } = default!;
}