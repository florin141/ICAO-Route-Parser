using System.Collections.Generic;
using System.Globalization;
using System.Text;
using RouteParser.RouteElements;
using RouteParser.RouteElements.SignificantPoints;

namespace RouteParser
{
    public class Route
    {
        private readonly string _routeString;

        private List<RouteElement> _routeElements;

        public List<RouteElement> RouteElements
        {
            get
            {
                if (_routeElements == null)
                {
                    Init();
                }

                return _routeElements;
            }
        }

        /// <summary>
        /// Constructs a route object from a given string in ICAO Route Plan format
        /// 
        /// Only use in conjunction with valid route strings
        /// </summary>
        /// <param name="routeString"></param>
        public Route(string routeString)
        {
            _routeString = routeString;
        }

        private void Init()
        {
            _routeElements = new List<RouteElement>();
            
            // Split string into tokens
            string[] routeStringParts = _routeString.Split(' ');

            // Create first element
            RouteElement firstElement = RouteElementFactory
                .GetRouteElement(null, routeStringParts[0], routeStringParts[1]);
            _routeElements.Add(firstElement);

            // Create middle elements
            for (int i = 1; i < routeStringParts.Length - 1; i++)
            {
                RouteElement tempElement = RouteElementFactory
                    .GetRouteElement(_routeElements[_routeElements.Count - 1], routeStringParts[i], routeStringParts[i + 1]);
                _routeElements.Add(tempElement);
            }

            // Create last element
            RouteElement lastElement = RouteElementFactory
                .GetRouteElement(_routeElements[_routeElements.Count - 1], routeStringParts[routeStringParts.Length - 1], string.Empty); 
            _routeElements.Add(lastElement);
        }

        public IEnumerable<T> Search<T>() where T : SignificantPoint
        {
            var foundElements = new List<T>();

            foreach (var element in RouteElements)
            {
                switch (element)
                {
                    case T namedPoint:
                        foundElements.Add(namedPoint);
                        break;
                    case ChangeOfSpeedLevelPoint changeOfSpeedLevelPoint:

                        if (changeOfSpeedLevelPoint.Point is T point)
                        {
                            foundElements.Add(point);
                        }

                        break;
                }
            }

            return foundElements;
        }

        /// <summary>
        /// Prints out the Representation and type of each route element in the current instance on a new line
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var element in RouteElements)
            {
                sb.Append(string.Format(CultureInfo.InvariantCulture, "Representation is {0}, Type is {1}\n", element.Representation, element));
            }

            return sb.ToString();
        }
    }
}
