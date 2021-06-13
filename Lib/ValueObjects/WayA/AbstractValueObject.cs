using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lib.ValueObjects.WayA
{
    public abstract class AbstractValueObject<T> : IEquatable<T> where T : class
    {
        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            var type = GetType();
            var otherType = other.GetType();

            if (type != otherType)
            {
                return false;
            }

            var fields = GetFields(type);

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }
                }
                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals(obj as T);
        }

        public override int GetHashCode()
        {
            var fields = GetFields();

            const int startValue = 17;
            const int multiplier = 59;

            var hashCode = startValue;

            foreach (var field in fields)
            {
                var value = field.GetValue(this);

                if (value != null)
                {
                    hashCode = hashCode * multiplier + value.GetHashCode();
                }
            }

            return hashCode;
        }

        public static bool operator ==(AbstractValueObject<T> left, AbstractValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AbstractValueObject<T> left, AbstractValueObject<T> right)
        {
            return !Equals(left, right);
        }

        private static IEnumerable<FieldInfo> GetFields(Type type)
        {
            return type!.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            var type = GetType();

            var fields = new List<FieldInfo>();

            while (type != typeof(object))
            {
                fields.AddRange(GetFields(type));

                type = type!.BaseType;
            }

            return fields;
        }
    }
}
