using System.Collections.Generic;

namespace MyFootballManagerObjects
{
    public class MatchList:List<Match>
    {
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
            }
        }
    }
}
