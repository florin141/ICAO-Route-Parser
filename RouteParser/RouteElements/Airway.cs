using System.Text.RegularExpressions;

namespace RouteParser.RouteElements
{
    public class Airway : RouteElement {
        private readonly string _designator;
        
        public Airway(string designator)
            :base(designator)
        {
            _designator = designator;
        }

        public static bool IsValid(string candidate)
        {
            return Regex.IsMatch(candidate, @"\w{2,7}");
        }
    }
}