using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFootballManagerObjects;

namespace MyFootballMangerDAL
{
    public class MatchListFromMemory:MatchList
    {
        public List<Team> teams = new List<Team>();
        public void LoadData()
        {
            for (int i = 0; i < 3; i++)
            {
                Team t = new Team();
                teams.Add(t);
                t.ID = i;
                t.Name = $"team{i}";
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j) continue;

                    Match m = new Match();
                    m.ID = ((int)Math.Pow(i + 1, j+1)) ;// + i + j;
                    m.Date = new DateTime(2017, i + 1, j + 1);
                    m.HomeTeam = teams[i];
                    m.AwayTeam = teams[j];

                    m.Result = new Score();
                    m.Result.HomeScore = new Random(i).Next(6);
                    m.Result.AwayScore = new Random(j).Next(5);
                    this.Add(m);
                }
            }
        }
        //TODO: Andrei make linq to sort
        // Cum ar fi static?
        public void SortByPoints()
        {
            /* Basic Bubble Sort */
            int l = teams.Count;
            bool sorted;

            do
            {
                sorted = true;
                for (int i = 0; i < l - 1; i++)
                {
                    if (teams[i].ChampionshipPoints < teams[i + 1].ChampionshipPoints)
                    {
                        Team aux = teams[i];
                        teams[i] = teams[i + 1];
                        teams[i + 1] = aux;
                        sorted = false;
                    }

                    else if (teams[i].ChampionshipPoints == teams[i + 1].ChampionshipPoints)
                    {
                        if (teams[i].GoalsScored < teams[i + 1].GoalsScored)
                        {
                            Team aux = teams[i];
                            teams[i] = teams[i + 1];
                            teams[i + 1] = aux;
                            sorted = false;
                        }
                    }
                }
            } while (!sorted);
        }
    }
}
