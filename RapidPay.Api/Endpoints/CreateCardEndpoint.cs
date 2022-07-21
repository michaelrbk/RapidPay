using FastEndpoints;
using RapidPay.Api.Contracts.Requests;
using RapidPay.Api.Contracts.Responses;
using RapidPay.Api.Mapping;
using RapidPay.Api.Services;

namespace RapidPay.Api.Endpoints;

[HttpPost("cards")]
public class CreateCardEndpoint : Endpoint<CreateCardRequest, CardResponse>
{
    private readonly ICardService _cardService;

    public CreateCardEndpoint(ICardService cardService)
    {
        _cardService = cardService;
    }

    public override async Task HandleAsync(CreateCardRequest req, CancellationToken ct)
    {
        var card = req.ToCard();

        await _cardService.CreateAsync(card);

        await SendCreatedAtAsync<CreateCardEndpoint>(
            new {Id = card.Id.Value}, card.ToCardResponse(), generateAbsoluteUrl: true, cancellation: ct);
    }
}