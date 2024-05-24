using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAproject
{
    [Serializable()]
    public class Team
    {
        private string _teamId;
        private string _teamName;
        private string _teamCity;
        private string _wins_losses;
        private string _divisionId;


        public String TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }

        public String TeamName
        {
            get { return _teamName; }
            set { if (_teamName != value) _teamName = value; }
        }

        public String TeamCity
        {
            get { return _teamCity; }
            set { if (_teamCity != value) _teamCity = value; }
        }

        public String Wins_losses
        {
            get { return _wins_losses; }
            set { if (_wins_losses != value) _wins_losses = value; }
        }

        public String DivisionId
        {
            get { return _divisionId; }
            set { _divisionId = value; }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Team() : base() { }

        public Team(string teamName, string teamCity, string wins_losses)
        {
            _teamName = teamName;
            _teamCity = teamCity;
            _wins_losses = wins_losses;
        }
    }
}
