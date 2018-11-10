using System;

namespace ProductManagement.Domain._base
{
    public abstract class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public override bool Equals(object other) => Equals(other as T);

        public virtual bool Equals(T otherValueObject)
        {
            if (ReferenceEquals(null, otherValueObject)) return false;
            if (ReferenceEquals(this, otherValueObject)) return true;
            return AllAttributesAreEqual(otherValueObject);
        }

        public override int GetHashCode()
        {
            return HashCode();
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !Equals(left, right);
        }

        protected abstract bool AllAttributesAreEqual(T otherValueObject);
        protected abstract int HashCode();
    }
}