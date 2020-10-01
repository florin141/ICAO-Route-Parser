using System.Text.RegularExpressions;

namespace RouteParser.RouteElements
{
    public class ChangeOfFlightRule : RouteElement {
        private string _flightRule;
        
        public ChangeOfFlightRule(string flightRule) 
            : base(flightRule)
        {
            _flightRule = flightRule;
        }

        public static bool IsValid(string candidate)
        {
            return Regex.IsMatch(candidate, @"IFR|VFR");
        }
    }
}