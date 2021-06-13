using System;

namespace Lib.ValueObjects.WayA
{
    public class Date : AbstractValueObject<Date>
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
    }
}
