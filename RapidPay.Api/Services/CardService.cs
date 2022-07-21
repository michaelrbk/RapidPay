using FluentValidation;
using FluentValidation.Results;
using RapidPay.Api.Domain;
using RapidPay.Api.Mapping;
using RapidPay.Api.Repositories;

namespace RapidPay.Api.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;

    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
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

    public async Task<bool> UpdateAsync(Card card)
    {
        var cardDto = card.ToCardDto();
        return await _cardRepository.UpdateAsync(cardDto);
    }
}