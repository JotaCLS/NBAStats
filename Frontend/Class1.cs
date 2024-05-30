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
        public string fgm { get; set; }
        public string fga { get; set; }
        public string threeptm { get; set; }
        public string threepta { get; set; }
        public string ftm { get; set; }
        public string fta { get; set; }
        public string offReb { get; set; }
        public string defReb { get; set; }
        public string assits { get; set; }
        public string steals { get; set; }
        public string block { get; set; }
        public string tov { get; set; }
        public string fouls { get; set; }
        public string point { get; set; } 


        public override string ToString()
        {
            return $"{Date} - {HomeTeamName} - {HomeTeamPoints} vs {AwayTeamPoints} - {AwayTeamName}";
        }
    }


}
