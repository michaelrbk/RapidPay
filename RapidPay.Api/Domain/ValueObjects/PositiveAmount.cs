using ValueOf;

namespace RapidPay.Api.Domain.ValueObjects;

public class PositiveAmount : ValueOf<decimal, PositiveAmount>
{
    protected override void Validate()
    {
        if (Value < 0) throw new ArgumentException("Amount cannot be negative", nameof(Id));
    }
}