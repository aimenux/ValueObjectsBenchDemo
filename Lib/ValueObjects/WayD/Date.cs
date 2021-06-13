using System;

namespace Lib.ValueObjects.WayD
{
    public class Date : IEquatable<Date>
    {
        public Date(DateTimeOffset value)
        {
            Value = value;
        }

        public DateTimeOffset Value { get; }

        public bool Equals(Date other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Date) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Date left, Date right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Date left, Date right)
        {
            return !Equals(left, right);
        }

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
