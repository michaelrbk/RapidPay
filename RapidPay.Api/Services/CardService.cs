using FluentValidation;
using FluentValidation.Results;
using RapidPay.Api.Domain;
using RapidPay.Api.Domain.ValueObjects;
using RapidPay.Api.Mapping;
using RapidPay.Api.Repositories;

namespace RapidPay.Api.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly UFEBackgroundService _ufe;

    public CardService(ICardRepository cardRepository, UFEBackgroundService ufe)
    {
        _cardRepository = cardRepository;
        _ufe = ufe;
    }

    public async Task<bool> CreateAsync(Card card)
    {
        var existingCard = await _cardRepository.GetAsync(card.Id.Value);
        if (existingCard is not null)
        {
            var message = $"A card with id {card.Id} already exists";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Card), message)
            });
        }

        var cardDto = card.ToCardDto();
        return await _cardRepository.CreateAsync(cardDto);
    }

    public async Task<Card?> GetAsync(Guid id)
    {
        var cardDto = await _cardRepository.GetAsync(id);
        return cardDto?.ToCard();
    }

    public async Task<bool> PayAsync(Card card, PositiveAmount amount)
    {
        Console.WriteLine($"Pay Card:{card.Id} Amount:{amount} Fee:{_ufe.Fee}");
        var payDto = card.ToPayDto(amount, _ufe.Fee);

        return await _cardRepository.PayAsync(payDto);
    }
}