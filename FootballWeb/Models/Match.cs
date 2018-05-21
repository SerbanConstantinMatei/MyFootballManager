using System;
using System.Collections.Generic;

namespace FootballWeb.Models
{
    public partial class Match
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int IdTeamHome { get; set; }
        public int IdTeamAway { get; set; }
        public int IdScore { get; set; }

        public Score IdScoreNavigation { get; set; }
        public Team IdTeamAwayNavigation { get; set; }
        public Team IdTeamHomeNavigation { get; set; }
    }
}
