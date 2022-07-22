using FastEndpoints;
using FluentValidation;

namespace RapidPay.Api.Contracts.Requests;

public class PayRequestValidator : Validator<PayRequest>
{
    public PayRequestValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.Amount).GreaterThan(Decimal.Zero);
    }
}