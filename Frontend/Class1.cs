using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAproject
{
    public class Game
    {
        public string GameId { get; set; }
        public string Date { get; set; }
        public string SeasonId { get; set; }
        public string HomeTeamPoints { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamPoints { get; set; }
        public string AwayTeamName { get; set; }

        public override string ToString()
        {
            return $"{Date} - {HomeTeamName} - {HomeTeamPoints} vs {AwayTeamPoints} - {AwayTeamName}";
        }
    }


}
