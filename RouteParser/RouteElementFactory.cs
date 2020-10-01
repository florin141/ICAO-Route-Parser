using RouteParser.RouteElements;
using RouteParser.RouteElements.SignificantPoints;

namespace RouteParser
{
    /// <summary>
    /// Factory class to create route elements
    /// Needs two adjacent elements to correctly parse the current string, it is to be used by route constructor
    /// </summary>
    public static class RouteElementFactory
    {
        private static SignificantPoint GetSignificantPoint(string current)
        {
            if (NavaidPoint.IsValid(current))
            {
                // Create NavaidPoint
                return new NavaidPoint(current);
            }
            // Check CoordinatePoint
            else if (CoordinatePoint.IsValid(current))
            {
                //Create CoordinatePoint
                return new CoordinatePoint(current);
            }
            // Definitely NamedPoint
            else
            {
                return new NamedPoint(current);
            }
        }

        public static RouteElement GetRouteElement(RouteElement previous, string current, string next)
        {
            // Check Direct
            if (Direct.IsValid(current))
            {
                //Create a new Direct element
                return new Direct();
            }

            // First element
            if (previous == null)
            {
                //Either SpeedLevel or Airway
                if (SpeedLevel.IsValid(current))
                {
                    return new SpeedLevel(current);
                }
                // Definitely airway
                else
                {
                    return new Airway(current);
                }
            }
            // Middle element or last element
            else
            {
                // Last element
                if (next.Equals(string.Empty))
                {
                    // Either NamedPoint, CoordinatePoint or NavaidPoint or STAR(TO BE IMPLEMENTED)
                    // TODO: Implement STAR
                    return GetSignificantPoint(current);
                }
                // Middle element
                else
                {
                    // Either ChangeOfFlightRule, ChangeOfSpeedLevelPoint, NavaidPoint, CoordinatePoint, NamedPoint or Airway
                    // Check ChangeOfFlightRule
                    if (ChangeOfFlightRule.IsValid(current))
                    {
                        return new ChangeOfFlightRule(current);
                    }
                    // Check ChangeOfSpeedLevelPoint
                    else if (ChangeOfSpeedLevelPoint.IsValid(current))
                    {
                        string[] currentParts = current.Split('/');

                        SignificantPoint significantPoint = GetSignificantPoint(currentParts[0]);
                        SpeedLevel speedLevel = new SpeedLevel(currentParts[1]);
                        
                        return new ChangeOfSpeedLevelPoint(significantPoint, speedLevel);
                    }
                    // Check CoordinatePoint before checking airway since they can be adjacent
                    else if (CoordinatePoint.IsValid(current))
                    {
                        //Create CoordinatePoint
                        return new CoordinatePoint(current);
                    }
                    // Either SignificantPoint or Airway
                    // Find the type of previous element
                    else if (previous is Airway | previous is SpeedLevel | previous is Direct)
                    {
                        // Current is a NamedPoint
                        return GetSignificantPoint(current);
                    }
                    else
                    {
                        // Current is an Airway
                        return new Airway(current);
                    }
                }
            }
        }
    }
}