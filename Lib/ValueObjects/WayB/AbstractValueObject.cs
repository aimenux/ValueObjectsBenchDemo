using System.Collections.Generic;
using System.Linq;

namespace Lib.ValueObjects.WayB
{
    public abstract class AbstractValueObject
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            var valueObject = (AbstractValueObject) obj;

            return GetEqualityFields().SequenceEqual(valueObject.GetEqualityFields());
        }

        public override int GetHashCode()
        {
            return GetEqualityFields()
                .Select(x => x?.GetHashCode() ?? 0)
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
