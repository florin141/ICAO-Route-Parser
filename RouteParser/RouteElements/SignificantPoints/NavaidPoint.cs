using System.Text.RegularExpressions;

namespace RouteParser.RouteElements.SignificantPoints
{
    public class NavaidPoint : SignificantPoint
    {
        private readonly string _navaidName;
        private readonly string _bearing;
        private readonly string _distance;

        public static bool IsValid(string candidate){
            return Regex.IsMatch(candidate, @"(?<navaid>\w{2,3})(?<bearing>\d{3})(?<distance>\d{3})");
        }
        public NavaidPoint(string navaidName, string bearing, string distance)
            : base(navaidName+bearing+distance)
        {
            _navaidName = navaidName;
            _bearing = bearing;
            _distance = distance;
        }

        public NavaidPoint(string representation)
            :base(representation)
        {
            // Create NavaidPoint from string
            Match m = Regex.Match(representation, @"(?<navaid>\w{2,3})(?<bearing>\d{3})(?<distance>\d{3})");

            _navaidName = m.Groups["navaid"].Value;
            _bearing = m.Groups["bearing"].Value;
            _distance = m.Groups["distance"].Value;
        }
    }
}