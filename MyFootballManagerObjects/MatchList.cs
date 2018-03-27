using System.Collections.Generic;
using System.Linq;

namespace MyFootballManagerObjects
{
    public class MatchList:List<Match>
    {
        public MatchList()
        {

        }
        public List<Team> teams = new List<Team>();
        public void SortByPoints()
        {

            //this.teams.Sort(new CompareTeamByPoints());
            this.teams.Sort((x, y) => y.ChampionshipPoints.CompareTo(x.ChampionshipPoints));
        }

        public Team[] Winners()
        {
            var maxim = this.teams.Max((x) => x.ChampionshipPoints);
            var result = this.teams.Where((x) => x.ChampionshipPoints == maxim);
            return result.ToArray();

        }

        public Team[] Losers()
        {
            var minim = this.teams.Min((x) => x.ChampionshipPoints);
            var result = this.teams.Where((x) => x.ChampionshipPoints == minim);
            return result.ToArray();
        }

        public new void Add(Match m)
        {
            base.Add(m);
            m.HomeTeam.GoalsScored += m.Result.HomeScore;
            m.AwayTeam.GoalsScored += m.Result.AwayScore;

            if (m.Result.HomeScore > m.Result.AwayScore)
            {
                m.HomeTeam.ChampionshipPoints += 3;
            }
            else if (m.Result.HomeScore < m.Result.AwayScore)
            {
                m.AwayTeam.ChampionshipPoints += 3;
            }
            else
            {
                m.AwayTeam.ChampionshipPoints++;
                m.HomeTeam.ChampionshipPoints++;
            } //todo: Read fluent builder and add match to machlist (make a function), strategy
                //email amazon
        }
    }
}
