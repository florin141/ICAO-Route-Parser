using System;

namespace RouteParser
{
    /// <summary>
    /// Class for holding flight level units
    /// Includes Standard Flight Level, Standard Metric, Altitude in Feet and Altitude in Meters
    /// </summary>
    [Serializable]
    public sealed class LevelUnit : NameValuePair
    {
        public static LevelUnit FlightLevel { get; } = new LevelUnit(1, "F");

        public static LevelUnit StandardMetric { get; } = new LevelUnit(2, "S");

        public static LevelUnit AltitudeInFeet { get; } = new LevelUnit(3, "A");

        public static LevelUnit AltitudeInMeter { get; } = new LevelUnit(4, "M");

        private LevelUnit(int value, string name)
            : base(value, name)
        { }

        public static implicit operator LevelUnit(string x)
        {
            switch (x)
            {
                case "F":
                    return FlightLevel;
                case "S":
                    return StandardMetric;
                case "A":
                    return AltitudeInFeet;
                case "M":
                    return AltitudeInMeter;
                default:
                    return null;
            }
        }

        public static implicit operator LevelUnit(int x)
        {
            switch (x)
            {
                case 1:
                    return FlightLevel;
                case 2:
                    return StandardMetric;
                case 3:
                    return AltitudeInFeet;
                case 4:
                    return AltitudeInMeter;
                default:
                    return null;
            }
        }
    }
}