using System;
using System.Collections.Generic;

namespace FootballWeb.Models
{
    public partial class Team
    {
        public Team()
        {
            MatchIdTeamAwayNavigation = new HashSet<Match>();
            MatchIdTeamHomeNavigation = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ChampionshipPoints { get; set; }
        public int GoalsScored { get; set; }

        public ICollection<Match> MatchIdTeamAwayNavigation { get; set; }
        public ICollection<Match> MatchIdTeamHomeNavigation { get; set; }
    }
}
