using ValueOf;

namespace RapidPay.Api.Domain.ValueObjects;

public class CardNumber : ValueOf<string, CardNumber>
{
    protected override void Validate()
    {
        if (Value == string.Empty) throw new ArgumentException("Id cannot be empty", nameof(Id));
    }
}