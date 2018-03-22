using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFootballManagerObjects
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ChampionshipPoints { get; set; }
        public int GoalsScored { get; set; }
    }
    public class CompareTeamByPoints : IComparer<Team>
    {
        public int Compare(Team x, Team y)
        {
            return x.ChampionshipPoints.CompareTo(y.ChampionshipPoints);
        }
    }
}
