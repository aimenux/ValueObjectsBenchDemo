using System;
using System.Collections.Generic;

namespace Lib.ValueObjects.WayC
{
    public class Date : AbstractValueObject
    {
        public Date(DateTimeOffset value)
        {
            Value = value;
        }

        public DateTimeOffset Value { get; }

        public static implicit operator DateTimeOffset?(Date date)
        {
            return date?.Value;
        }

        public static implicit operator DateTimeOffset(Date date)
        {
            return date?.Value ?? default;
        }

        protected override IEnumerable<object> GetEqualityFields()
        {
            yield return Value;
        }
    }
}
