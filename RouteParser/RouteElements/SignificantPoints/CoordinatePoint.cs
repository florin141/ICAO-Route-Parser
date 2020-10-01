using System.Text.RegularExpressions;

namespace RouteParser.RouteElements.SignificantPoints
{
    public class CoordinatePoint : SignificantPoint
    {
        private const string CoordinatePointPattern = @"(?<vertical>(\d{2}|\d{4})[N,S])(?<horizontal>((\d{3}|\d{5})[E,W]))";

        private readonly string _verticalCoordinate;
        private readonly string _horizontalCoordinate;

        public CoordinatePoint(string verticalCoordinate, string horizontalCoordinate)
            : base(verticalCoordinate+horizontalCoordinate)
        {
            _verticalCoordinate = verticalCoordinate;
            _horizontalCoordinate = horizontalCoordinate;
        }

        public CoordinatePoint(string representation)
            :base(representation)
        {
            Match m = Regex.Match(representation, CoordinatePointPattern);
            
            string vertical = m.Groups["vertical"].Value;
            string horizontal = m.Groups["horizontal"].Value;
            
            _verticalCoordinate = vertical;
            _horizontalCoordinate = horizontal;
        }

        public static bool IsValid(string candidate)
        {
            return Regex.IsMatch(candidate, CoordinatePointPattern);
        }
    }
}