using System.Collections.Generic;
using System.Linq;

namespace Lib.ValueObjects.WayC
{
    public abstract class AbstractValueObject
    {
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (AbstractValueObject) obj;

            using var thisValues = GetEqualityFields().GetEnumerator();
            using var otherValues = other.GetEqualityFields().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetEqualityFields()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(AbstractValueObject left, AbstractValueObject right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AbstractValueObject left, AbstractValueObject right)
        {
            return !Equals(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityFields();
    }
}
