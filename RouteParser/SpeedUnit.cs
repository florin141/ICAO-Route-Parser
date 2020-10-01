using System;

namespace RouteParser
{
    /// <summary>
    /// Class for holding cruising speed units
    /// Includes Kilometer, Knot and Mach
    /// </summary>
    [Serializable]
    public sealed class SpeedUnit : NameValuePair
    {
        public static SpeedUnit Kilometer { get; } = new SpeedUnit(1, "K");
        public static SpeedUnit Knot { get; } = new SpeedUnit(2, "N");
        public static SpeedUnit Mach { get; } = new SpeedUnit(3, "M");

        private SpeedUnit(int value, string name)
            : base(value, name)
        { }

        public static implicit operator SpeedUnit(string x)
        {
            switch (x)
            {
                case "K":
                    return Kilometer;
                case "N":
                    return Knot;
                case "M":
                    return Mach;
                default:
                    return null;
            }
        }

        public static implicit operator SpeedUnit(int x)
        {
            switch (x)
            {
                case 1:
                    return Kilometer;
                case 2:
                    return Knot;
                case 3:
                    return Mach;
                default:
                    return null;
            }
        }
    }
}