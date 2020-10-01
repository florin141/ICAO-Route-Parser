using System.Text.RegularExpressions;

namespace RouteParser.RouteElements
{
    public class Direct : RouteElement {
        public Direct() : base("DCT") { }

        public static bool IsValid(string candidate)
        {
            return Regex.IsMatch(candidate, @"DCT");
        }
    }
}