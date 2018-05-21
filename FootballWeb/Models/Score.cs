using System;
using System.Collections.Generic;

namespace FootballWeb.Models
{
    public partial class Score
    {
        public Score()
        {
            Match = new HashSet<Match>();
        }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int Id { get; set; }

        public ICollection<Match> Match { get; set; }
    }
}
