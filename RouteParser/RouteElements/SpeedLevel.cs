using System.Text.RegularExpressions;

namespace RouteParser.RouteElements
{
    public class SpeedLevel : RouteElement {
        private SpeedUnit _speedunit;
        private string _speed;
        private LevelUnit _levelunit;
        private string _level;

        public static bool IsValid(string candidate){
            return Regex.IsMatch(candidate, @"(?<speed>[K,N]\d{4}|M\d{3})(?<clevel>([A,F]\d{3})|[S,M]\d{4})");
        }
        public SpeedLevel(SpeedUnit speedunit, string speed, LevelUnit levelunit, string level)
            :base(speedunit+speed+levelunit+level)
        {
            this._speedunit = speedunit;
            this._speed = speed;
            this._levelunit = levelunit;
            this._level = level;
                
        }

        public SpeedLevel(string representation)
            :base(representation)
        {
            Match m = Regex.Match(representation, @"(?<speed>[K,N]\d{4}|M\d{3})(?<level>([A,F]\d{3})|[S,M]\d{4})");
            string speed = m.Groups["speed"].Value;
            string level = m.Groups["level"].Value;
            //Get units for speed and level
            this._speedunit = speed.Substring(0, 1);
            this._levelunit = level.Substring(0, 1);
            this._speed = speed.Substring(1);
            this._level = level.Substring(1);
        }
    }
}