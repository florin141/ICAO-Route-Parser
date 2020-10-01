using System;

namespace RouteParser
{
    [Serializable]
    public abstract class NameValuePair
    {
        protected readonly string Name;
        protected readonly int Value;

        protected NameValuePair(int value, string name)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator string(NameValuePair x)
        {
            return x.Name;
        }

        public static implicit operator int(NameValuePair x)
        {
            return x.Value;
        }

        public static bool operator ==(NameValuePair x, NameValuePair y)
        {
            if (x == null || y == null)
            {
                return false;
            }

            if (ReferenceEquals(x, y))
            {
                return true;
            }

            return (x.Value == y.Value);
        }

        public static bool operator !=(NameValuePair x, NameValuePair y)
        {
            return x.Value != y.Value;
        }

        public override bool Equals(object obj)
        {
            var p = obj as NameValuePair;

            if (p == null)
            {
                return false;
            }

            return (Value == p.Value);
        }

        public bool Equals(NameValuePair flag)
        {
            return (Value == flag.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}