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
        public string _teamId;
        private string _teamName;
        private string _teamCity;
        private string _divisionId;
        private string _wins_losses;
        private string _teamCoach;
        private string _teamConference;
        private string _teamDivision;
        


        
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

        public String TeamCoach
        {
            get { return _teamCoach; }
            set { if (_teamCoach != value) _teamCoach = value; }
        }

        public String TeamConference
        {
            get { return _teamConference; }
            set { if (_teamConference != value) _teamConference = value; }
        }

        public String TeamDivision
        {
            get { return _teamDivision; }
            set { if (_teamDivision != value) _teamDivision = value; }
        }

        public String DivisionId
        {
            get { return _divisionId; }
            set { if (_divisionId != value) _divisionId = value; }
        }


        public override string ToString()
        {
            return TeamName;
        }

        public Team() : base() { }

        public Team(string teamId, string teamName, string teamCity, string wins_losses, string teamCoach, string teamConference, string teamDivision)
        {
            _teamId = teamId;
            _teamName = teamName;
            _teamCity = teamCity;
            _wins_losses = wins_losses;
            _teamCoach = teamCoach;
            _teamDivision = teamDivision;
            _teamConference = teamConference;
        }
    }
}
