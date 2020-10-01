using System.Globalization;

namespace RouteParser.RouteElements
{
    /// <summary>
    /// Classes for representing route elements
    /// Includes significant points, airways, directs, change of flight speeds and rules
    /// </summary>
    public abstract class RouteElement
    {
        public string Representation { get; }

        protected RouteElement(string representation)
        {

            Representation = representation;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, 
                "Representation is {0}, Type is {1}\n", Representation, GetType().Name);
        }
    }
}