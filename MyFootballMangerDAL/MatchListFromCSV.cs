using MyFootballManagerObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyFootballMangerDAL
{
    public class MatchListFromCSV:MatchList
    {
        public List<Team> teams = new List<Team>();
        public void LoadData()
        {
            string path = "..\\..\\..\\Data\\Data.txt";
            using (var reader = new StreamReader(path))
            {

                //IValidatableObject pentru rinduri ncorecte
                int n;
                int.TryParse(reader.ReadLine(), out n);
                for (int i = 0; i < n; i++)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Match m = new Match();

                    int id;
                    int.TryParse(values[0], out id);
                    m.ID = id;

                    int year, month, day;
                    int.TryParse(values[1], out day);
                    int.TryParse(values[2], out month);
                    int.TryParse(values[3], out year);
                    m.Date = new DateTime(year, month, day);

                    m.HomeTeam = new Team();
                    m.AwayTeam = new Team();
                    m.HomeTeam.Name = values[4];
                    m.AwayTeam.Name = values[5];

                    int score;
                    m.Result = new Score();
                    int.TryParse(values[6], out score);
                    m.Result.HomeScore = score;
                    int.TryParse(values[7], out score);
                    m.Result.AwayScore = score;

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
                    this.Add(m);
                }
            }
        }
    }
}
