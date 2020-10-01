using System.Text.RegularExpressions;

namespace RouteParser.RouteElements.SignificantPoints
{
    public class NamedPoint : SignificantPoint
    {
        private readonly string _name;

        public NamedPoint(string name)
            : base(name)
                
        {
            _name = name;
        }

        public static bool IsValid(string candidate)
        {
            return Regex.IsMatch(candidate, @"\D{2,5}");
        }
    }
}