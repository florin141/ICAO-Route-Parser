using System.Globalization;
using RouteParser.RouteElements.SignificantPoints;

namespace RouteParser.RouteElements
{
    public class ChangeOfSpeedLevelPoint : RouteElement {
        
        private readonly SignificantPoint _point;
        public SignificantPoint Point => _point;

        private SpeedLevel _changeOfSpeedLevel;

        public ChangeOfSpeedLevelPoint(SignificantPoint point, SpeedLevel changeOfSpeedLevel)
            : base(string.Format(CultureInfo.InvariantCulture, "{0}/{1}", point.Representation, changeOfSpeedLevel.Representation))
        {
            _point = point;
            _changeOfSpeedLevel = changeOfSpeedLevel;
        }

        public static bool IsValid(string candidate)
        {
            string[] candidateParts = candidate.Split('/');

            if (candidateParts.Length != 2)
            {
                return false;
            }

            var pointPart = candidateParts[0];
            var speedLevelPart = candidateParts[1];

            // Check point part for each category and check speed level part.
            return SpeedLevel.IsValid(speedLevelPart) &&
                   (NavaidPoint.IsValid(pointPart) ||
                    CoordinatePoint.IsValid(pointPart) ||
                    NamedPoint.IsValid(pointPart));
        }
    }
}