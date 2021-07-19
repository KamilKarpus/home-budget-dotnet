using System.Collections.Generic;

namespace HB.BuildingBlocks.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public string Currency { get; private set; }
        public decimal Amount { get; private set; }

        public Money(string currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency;
            yield return Amount;
        }
    }
}
