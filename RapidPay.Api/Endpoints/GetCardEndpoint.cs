using FastEndpoints;
using RapidPay.Api.Contracts.Requests;
using RapidPay.Api.Contracts.Responses;
using RapidPay.Api.Mapping;
using RapidPay.Api.Services;

namespace RapidPay.Api.Endpoints;

[HttpGet("cards/{CardId:guid}")]
public class GetCardEndpoint : Endpoint<GetCardRequest, CardResponse>
{
    private readonly ICardService _cardService;

    public GetCardEndpoint(ICardService cardService)
    {
        _cardService = cardService;
    }

    public override async Task HandleAsync(GetCardRequest req, CancellationToken ct)
    {
        var card = await _cardService.GetAsync(req.CardId);

        if (card is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendOkAsync(card.ToCardResponse(), ct);
    }
}