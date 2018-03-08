using System.Collections.Generic;

namespace MyFootballManagerObjects
{
    public class MatchList:List<Match>
    {
        public new void Add(Match m)
        {
            base.Add(m);
            //TODO: update leader board
            //TODO: protected, internal, publc, private?
            //System.Console.WriteLine("add");
            //TODO: calculate leaderboard not on real time, but on demand
        }
    }
}
