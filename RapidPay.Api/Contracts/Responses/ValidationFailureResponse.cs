namespace RapidPay.Api.Contracts.Responses;

public class ValidationFailureResponse
{
    public List<string> Errors { get; init; } = new();
}