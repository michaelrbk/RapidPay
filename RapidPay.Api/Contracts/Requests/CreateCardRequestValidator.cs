using FastEndpoints;
using FluentValidation;

namespace RapidPay.Api.Contracts.Requests;

public class CreateCardRequestValidator : Validator<CreateCardRequest>
{
    public CreateCardRequestValidator()
    {
        RuleFor(x => x.CardNumber).NotEmpty();
        RuleFor(x => x.CardNumber).Length(15);
    }
}