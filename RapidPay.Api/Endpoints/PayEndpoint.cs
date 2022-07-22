using FastEndpoints;
using RapidPay.Api.Contracts.Requests;
using RapidPay.Api.Contracts.Responses;
using RapidPay.Api.Domain.ValueObjects;
using RapidPay.Api.Mapping;
using RapidPay.Api.Services;

namespace RapidPay.Api.Endpoints;

[HttpPost("cards/{CardId:guid}/pay")]
public class PayEndpoint : Endpoint<PayRequest>
{
    private readonly ICardService _cardService;

    public PayEndpoint(ICardService cardService)
    {
        _cardService = cardService;
    }

    public override async Task HandleAsync(PayRequest req, CancellationToken ct)
    {
        var card = await _cardService.GetAsync(req.CardId);

        if (card is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await _cardService.PayAsync(card, PositiveAmount.From(req.Amount));

        await SendOkAsync(ct);
    }
}